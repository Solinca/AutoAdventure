public class HealthData
{
    public event EVENT.IntEvent MaxHealthIncreased;

    public int MaxHealth => _maxHealth;

    private int _maxHealth = 0;

    public void IncreaseMaxHealth()
    {
        GainHealth(1);

        _maxHealth++;

        MaxHealthIncreased?.Invoke(1);
    }

    public void IncreaseMaxHealth(int amountGained)
    {
        GainHealth(amountGained);

        _maxHealth += amountGained;

        MaxHealthIncreased?.Invoke(amountGained);
    }

    // ------------------------------------------------ //

    public event EVENT.IntEvent CurrentHealthChanged;

    public int CurrentHealth => _currentHealth;

    private int _currentHealth = 0;

    public void SetCurrentHealth(int currentHealth)
    {
        CurrentHealthChanged?.Invoke(_currentHealth = currentHealth);
    }

    public void GainHealth(int amountGained)
    {
        CurrentHealthChanged?.Invoke(_currentHealth += amountGained);
    }

    public void LoseHealth(int amountLost)
    {
        CurrentHealthChanged?.Invoke(_currentHealth -= amountLost);
    }
}
