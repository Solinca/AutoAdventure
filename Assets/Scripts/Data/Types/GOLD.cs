public class GoldData
{
    public int CurrentGold => _currentGold;

    public event EVENT.GameEvent CurrentGoldChanged;

    public void IncreaseCurrentGold()
    {
        _currentGold++;

        CurrentGoldChanged.Invoke();
    }

    public void IncreaseCurrentGold(int amount)
    {
        _currentGold += amount;

        CurrentGoldChanged.Invoke();
    }

    public void DecreaseCurrentGold(int amount)
    {
        _currentGold -= amount;

        CurrentGoldChanged.Invoke();
    }

    private int _currentGold;
}
