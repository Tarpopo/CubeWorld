using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class DashAttack : BaseAttack
{
    public DashAttackData Data => _dashAttackData;
    [SerializeField] private Transform _particlesPoint;
    [SerializeField] private DashAttackData _dashAttackData;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private AnimationComponent _animationComponent;
    private Collider[] _colliders = new Collider[5];

    public override void StartAttack()
    {
        // _animationComponent.PlayAnimation(_dashAttackData.AttackAnimation);
        StartCoroutine(StartDash());
    }

    public override void StopAttack() => StopAllCoroutines();

    public override void TryApplyDamage()
    {
        Physics.OverlapSphereNonAlloc(transform.position, _dashAttackData.AttackRadius, _colliders);
        for (int i = 0; i < _colliders.Length; i++)
        {
            if (_colliders[i].TryGetComponent<IDamageable>(out var damageable) == false) continue;
            damageable.TakeDamage(_dashAttackData.Damage);
        }
    }

    public IEnumerator StartDash()
    {
        var time = _dashAttackData.DashTime;
        Attacking = true;
        _animationComponent.PlayAnimation(UnitAnimations.AttackSit);
        yield return new WaitForSeconds(_dashAttackData.AttackStartDelay);
        _dashAttackData.MeshParticlesPool.Get(_particlesPoint.position);
        yield return new WaitForSeconds(_dashAttackData.AttackStartDelay / 2);
        _animationComponent.PlayAnimation(UnitAnimations.AttackJump);
        while (time > 0)
        {
            time -= Time.deltaTime;
            Move();
            yield return null;
        }

        Attacking = false;
    }

    private void Awake() => _dashAttackData.MeshParticlesPool.Load();

    private void Move() => _navMeshAgent.Move(transform.forward * _dashAttackData.DashSpeed);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _dashAttackData.GizmosColor;
        Gizmos.DrawWireSphere(transform.position, _dashAttackData.AttackRadius);
    }
}