public class LUCK_DATA
{
    public EVENT.IntEvent LuckIncreased;

    // ------------------------------------------------ //

    public int CurrentLuck => _currentLuck;

    private int _currentLuck = 0;

    public void IncreaseLuck()
    {
        _currentLuck++;
    }

    public void IncreaseLuck(int amountGained)
    {
        _currentLuck += amountGained;
    }
}
