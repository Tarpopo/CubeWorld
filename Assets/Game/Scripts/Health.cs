using System;

public class Health
{
    public event Action<int> OnReduceHealth;
    public event Action<int> OnHealthAdded;
    public event Action OnHealthEnd;
    public int CurrentHealth { get; private set; }
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
        OnReduceHealth?.Invoke(CurrentHealth);
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
        OnHealthAdded?.Invoke(CurrentHealth);
    }
}