public class GAME_STATUS_DATA
{
    public EVENT.GameStatusEvent CurrentGameStatusChanged;

    public GAME_STATUS GameStatus => _gameStatus;

    private GAME_STATUS _gameStatus;

    public void SetGameState(GAME_STATUS status)
    {
        _gameStatus = status;

        CurrentGameStatusChanged?.Invoke(status);
    }
}
