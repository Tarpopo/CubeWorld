using UnityEngine;

public abstract class BaseAttack : MonoBehaviour, IAttack
{
    public IAttack Attack => this;
    public bool Attacking { get; protected set; }

    public abstract void StartAttack();

    public abstract void StopAttack();

    public abstract void TryApplyDamage();
}