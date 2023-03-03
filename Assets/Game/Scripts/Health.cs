using System;

public class Health : IHealth
{
    public event Action<int> OnReduceHealthInt;
    public event Action OnReduceHealth;
    public event Action<int> OnHealthAddedInt;
    public event Action OnHealthAdded;
    public event Action OnHealthEnd;
    public int CurrentHealth { get; private set; }
    public bool MaxHealth => CurrentHealth >= _maxHealth;
    private int _maxHealth;

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        ResetHealth();
    }

    public void ResetHealth() => CurrentHealth = _maxHealth;

    public void ReduceHealth(int damage)
    {
        if (CurrentHealth <= 0) return;
        CurrentHealth -= damage;
        OnReduceHealthInt?.Invoke(CurrentHealth);
        OnReduceHealth?.Invoke();
        if (CurrentHealth <= 0) OnHealthEnd?.Invoke();
    }

    public void AddHealth(int value)
    {
        if (CurrentHealth + value >= _maxHealth)
        {
            CurrentHealth = _maxHealth;
            return;
        }

        CurrentHealth += value;
        OnHealthAdded?.Invoke();
        OnHealthAddedInt?.Invoke(CurrentHealth);
    }

    public void AddHealth() => AddHealth(1);
}