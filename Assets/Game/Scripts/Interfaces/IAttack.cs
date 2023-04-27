public interface IAttack
{
    bool Attacking { get; }
    public void StartAttack();
    public void StopAttack();
    public void TryApplyDamage();
}