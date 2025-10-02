public class DamageData
{
    public event EVENT.IntEvent DamageIncreased;

    public int CurrentDamage => _currentDamage;

    private int _currentDamage = 0;

    public void IncreaseDamage()
    {
        DamageIncreased?.Invoke(_currentDamage++);
    }

    public void IncreaseDamage(int amountGained)
    {
        DamageIncreased?.Invoke(_currentDamage += amountGained);
    }
}
