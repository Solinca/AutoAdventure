public class GoldData
{
    public event EVENT.IntEvent CurrentGoldChanged;

    public int CurrentGold => _currentGold;

    private int _currentGold = 0;

    public void IncreaseCurrentGold()
    {
        CurrentGoldChanged?.Invoke(_currentGold++);
    }

    public void IncreaseCurrentGold(int amount)
    {
        CurrentGoldChanged?.Invoke(_currentGold += amount);
    }

    public void DecreaseCurrentGold(int amount)
    {
        CurrentGoldChanged?.Invoke(_currentGold -= amount);
    }
}
