public class GameStatus
{
    public enum GAME_STATE
    {
        RUNNING,
        PAUSED,
        SHOPPING
    }

    public GAME_STATE GameState => _gameState;

    public void SetGameState(GAME_STATE state)
    {
        _gameState = state;
    }

    private GAME_STATE _gameState = GAME_STATE.RUNNING;
}
