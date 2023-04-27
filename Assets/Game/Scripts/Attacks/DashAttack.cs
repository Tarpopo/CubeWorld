using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[Serializable]
public class DashAttack : BaseAttack
{
    public DashAttackData Data => _dashAttackData;
    [SerializeField] private Transform _particlesPoint;
    [SerializeField] private DashAttackData _dashAttackData;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private AnimationComponent _animationComponent;
    private Collider[] _colliders = new Collider[5];
    private float _startY;

    public override void StartAttack()
    {
        _navMeshAgent.enabled = false;
        _startY = transform.position.y;
        _animationComponent.PlayAnimation(_dashAttackData.AttackAnimation);
        // StartCoroutine(StartDash());
        Attacking = true;
        StartCoroutine(LerpValue(transform.position,
            transform.position + (transform.forward * _dashAttackData.DashDistance), _dashAttackData.DashDuration,
            SetPosition, () => Attacking = false));
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

    private IEnumerator LerpValue(Vector3 startValue, Vector3 endValue, float duration,
        UnityAction<Vector3, float> action,
        UnityAction onEnd = null)
    {
        float elapsed = 0;
        while (elapsed <= duration)
        {
            action?.Invoke(Vector3.Lerp(startValue, endValue, elapsed / duration), elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        action?.Invoke(Vector3.Lerp(startValue, endValue, 1), 1);
        _navMeshAgent.enabled = true;
        onEnd?.Invoke();
    }

    private void SetPosition(Vector3 position, float timeValue)
    {
        transform.position =
            position.WithY(_startY + _dashAttackData.YCurve.Evaluate(timeValue) * _dashAttackData.YMultiply);
    }

    private void Awake() => _dashAttackData.MeshParticlesPool.Load();

    private void Move() => _navMeshAgent.Move(transform.forward * _dashAttackData.DashSpeed);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _dashAttackData.GizmosColor;
        Gizmos.DrawWireSphere(transform.position, _dashAttackData.AttackRadius);
    }
}