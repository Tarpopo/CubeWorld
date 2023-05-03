using System;
using UnityEngine;

[Serializable]
public class DashAttack : BaseAttack
{
    private Transform _transform;
    private Vector3 _startPosition;
    private DashAttackData _data;
    private readonly Collider[] _colliders = new Collider[5];
    private MonoBehaviour _monoBehaviour;
    private bool _giveDamage;

    public DashAttack(DashAttackData data, Transform transform, MonoBehaviour monoBehaviour)
    {
        _data = data;
        _transform = transform;
        _monoBehaviour = monoBehaviour;
    }

    public override void StartAttack()
    {
        base.StartAttack();
        _giveDamage = false;
        _startPosition = _transform.position;
        Attacking = true;
        _monoBehaviour.StartCoroutine(_startPosition.LerpValue(_startPosition + _transform.forward * _data.DashDistance,
            _data.AttackStartDelay, _data.DashDuration, SetPosition, TryApplyDamage, () => Attacking = false));
    }

    public override void StopAttack()
    {
        base.StopAttack();
        Attacking = false;
    }

    public override void TryApplyDamage()
    {
        if (_giveDamage) return;
        Physics.OverlapSphereNonAlloc(_transform.position, _data.AttackRadius, _colliders);
        foreach (var collider in _colliders)
        {
            if (collider == null || collider.TryGetComponent<IDamageable>(out var damageable) == false) continue;
            damageable.TakeDamage(_data.Damage);
            _giveDamage = true;
            break;
        }
    }

    private void SetPosition(Vector3 position, float timeValue)
    {
        _transform.position = _giveDamage
            ? _transform.position.WithY(_startPosition.y + _data.YCurve.Evaluate(timeValue) * _data.YMultiply)
            : position.WithY(_startPosition.y + _data.YCurve.Evaluate(timeValue) * _data.YMultiply);
    }
}