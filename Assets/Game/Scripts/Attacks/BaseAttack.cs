using System;

public abstract class BaseAttack : IAttack
{
    public IAttack Attack => this;
    public event Action OnStartAttack;
    public event Action OnStopAttack;
    public bool Attacking { get; protected set; }
    public virtual void StartAttack() => OnStartAttack?.Invoke();
    public virtual void StopAttack() => OnStopAttack?.Invoke();
    public abstract void TryApplyDamage();
}