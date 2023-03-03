public interface IHealth
{
    public int CurrentHealth { get; }
    public bool MaxHealth { get; }
    void ResetHealth();
    void AddHealth(int damage);
    void ReduceHealth(int damage);
}