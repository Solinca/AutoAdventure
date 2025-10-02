public class GameStatusData
{
    public EVENT.GameStatusEvent CurrentGameStatusChanged;

    public GAME_STATUS GameStatus => _gameStatus;

    public void SetGameState(GAME_STATUS status)
    {
        _gameStatus = status;

        CurrentGameStatusChanged.Invoke(status);
    }

    private GAME_STATUS _gameStatus;
}
