public class GameStatusData
{
    public EVENT.GameStatusEvent CurrentGameStatusChanged;

    public GAME_STATUS GameStatus => _gameStatus;

    private GAME_STATUS _gameStatus = GAME_STATUS.RUNNING;

    public void SetGameState(GAME_STATUS status)
    {
        _gameStatus = status;

        CurrentGameStatusChanged?.Invoke(status);
    }
}
