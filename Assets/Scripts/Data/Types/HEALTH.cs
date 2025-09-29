public class Health
{
    public int MaxHealth => _maxHealth;

    public event DATA.GameEvent MaxHealthIncreased;

    public void IncreaseMaxHealth()
    {
        _maxHealth++;
        _currentHealth++;

        MaxHealthIncreased.Invoke();
    }

    private int _maxHealth;

    public int CurrentHealth => _currentHealth;

    public event DATA.IntEvent CurrentHealthChanged;

    public void SetCurrentHealth(int currentHealth)
    {
        _currentHealth = currentHealth;

        CurrentHealthChanged.Invoke(currentHealth);
    }

    private int _currentHealth = 0;
}
