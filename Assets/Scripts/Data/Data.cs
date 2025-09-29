public static class DATA
{
    public delegate void GameEvent();
    public delegate void IntEvent(int value);
    public delegate void BoolEvent(bool value);

    public static GameStatus GAME_STATUS = new();
    public static Health HEALTH = new();
    public static Gold GOLD = new();
}
