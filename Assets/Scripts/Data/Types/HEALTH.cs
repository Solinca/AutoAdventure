public class HEALTH_DATA
{
    public EVENT.GameEvent HealthDepleted;

    public EVENT.IntEvent MaxHealthIncreased;

    public EVENT.GameEvent CurrentHealthChanged;

    public EVENT.IntEvent DamageTaken;

    // ------------------------------------------------ //

    public float TIME_TO_WAIT_AT_DEATH = 3;

    // ------------------------------------------------ //

    public int MaxHealth => _maxHealth;

    private int _maxHealth = 0;

    public void IncreaseMaxHealth()
    {
        _maxHealth++;
    }

    public void IncreaseMaxHealth(int amountGained)
    {
        _maxHealth += amountGained;
    }

    // ------------------------------------------------ //

    public int CurrentHealth => _currentHealth;

    private int _currentHealth = 0;

    public void GainHealth(int amountGained)
    {
        _currentHealth += amountGained;
    }

    public void LoseHealth(int amountLost)
    {
        _currentHealth -= amountLost;
    }

    public void SetCurrentHealth(int currentHealth)
    {
        _currentHealth = currentHealth;
    }
}
