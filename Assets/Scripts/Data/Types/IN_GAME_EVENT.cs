public class IN_GAME_EVENT_DATA
{
    public EVENT.InGameEventEvent EventStarting;
    public EVENT.GameEvent EventFinished;
    public EVENT.GameEvent CampaignCompleted;
    public EVENT.StringEvent ChatMessage;

    public string PLAYER_COLOR = "0022FF";
    public string DAMAGE_COLOR = "FF2020";
    public string GOLD_COLOR = "FFE600";

    public float TIME_BETWEEN_EVENT_STEP = 1;
    public float TIME_TO_WAIT_ON_COMPLETE = 3;
}
