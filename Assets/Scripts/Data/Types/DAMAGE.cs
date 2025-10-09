public class DAMAGE_DATA
{
    public EVENT.IntEvent DamageIncreased;

    public EVENT.GameEvent CurrentDamageChanged;

    // ------------------------------------------------ //

    public int CurrentDamage => _currentDamage;

    private int _currentDamage = 0;

    public void IncreaseDamage()
    {
        _currentDamage++;
    }

    public void IncreaseDamage(int amountGained)
    {
        _currentDamage += amountGained;
    }
}
