public class LuckData
{
    public event EVENT.IntEvent LuckIncreased;

    public int CurrentLuck => _currentLuck;

    private int _currentLuck = 0;

    public void IncreaseLuck()
    {
        LuckIncreased?.Invoke(_currentLuck++);
    }

    public void IncreaseLuck(int amountGained)
    {
        LuckIncreased?.Invoke(_currentLuck += amountGained);
    }
}
