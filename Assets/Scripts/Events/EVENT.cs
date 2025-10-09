public static class EVENT
{
    public delegate void GameEvent();
    public delegate void IntEvent(int value);
    public delegate void BoolEvent(bool value);
    public delegate void StringEvent(string value);
    public delegate void GameStatusEvent(GAME_STATUS status);
    public delegate void ShopItemEvent(ShopItemScriptableObject shopItem);
    public delegate void InGameEventEvent(InGameEventScriptableObject inGameEvent);
}
