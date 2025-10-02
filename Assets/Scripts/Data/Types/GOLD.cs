public class GOLD_DATA
{
    public EVENT.GameEvent CurrentGoldChanged;

    public EVENT.IntEvent GoldGained;

    // ------------------------------------------------ //

    public int CurrentGold => _currentGold;

    private int _currentGold = 0;

    public void IncreaseCurrentGold()
    {
        _currentGold++;
    }

    public void IncreaseCurrentGold(int amount)
    {
        _currentGold += amount;
    }

    public void DecreaseCurrentGold(int amount)
    {
        _currentGold -= amount;
    }
}
