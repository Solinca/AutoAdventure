public static class Data
{
    public delegate void GameEvent();
    public delegate void IntEvent(int value);
    public delegate void BoolEvent(bool value);



    // -------- IS PAUSED -------- //
    public static bool IsPaused => _isPaused;

    public static void SetIsPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }

    private static bool _isPaused;


    // -------- HEALTH -------- //
    public static int MaxHealth => _maxHealth;

    public static event GameEvent MaxHealthIncreased;

    public static void IncreaseMaxHealth()
    {
        _maxHealth++;

        MaxHealthIncreased.Invoke();
    }

    private static int _maxHealth;

    public static int CurrentHealth => _currentHealth;

    public static event IntEvent CurrentHealthChanged;

    public static void SetCurrentHealth(int currentHealth)
    {
        _currentHealth = currentHealth;

        CurrentHealthChanged.Invoke(currentHealth);
    }

    private static int _currentHealth;


    // -------- GOLD -------- //
    public static int CurrentGold => _currentGold;

    public static event GameEvent CurrentGoldChanged;

    public static void IncreaseCurrentGold()
    {
        _currentGold++;

        CurrentGoldChanged.Invoke();
    }

    public static void IncreaseCurrentGold(int amount)
    {
        _currentGold += amount;

        CurrentGoldChanged.Invoke();
    }

    public static void DecreaseCurrentGold(int amount)
    {
        _currentGold -= amount;

        CurrentGoldChanged.Invoke();
    }

    private static int _currentGold;
}
