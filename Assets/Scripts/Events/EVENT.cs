public static class EVENT
{
    public delegate void GameEvent();
    public delegate void IntEvent(int value);
    public delegate void BoolEvent(bool value);
    public delegate void GameStatusEvent(GAME_STATUS status);
    public delegate void ShopItemEvent(ShopItemScriptableObject item);
}
