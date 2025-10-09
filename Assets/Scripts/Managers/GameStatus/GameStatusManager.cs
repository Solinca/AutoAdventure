using UnityEngine;

public class GameStatusManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GAME_STATUS _gameStatusAtStart = GAME_STATUS.RUNNING;

    private void Awake()
    {
        DATA.SHOP.ShopClosed += OnShopClosed;
        DATA.HEALTH.HealthDepleted += OnHealthDepleted;
        DATA.IN_GAME_EVENT.EventStarting += OnEventStarting;
        DATA.IN_GAME_EVENT.EventFinished += OnEventFinished;
        DATA.IN_GAME_EVENT.CampaignCompleted += OnCampaignCompleted;
    }

    private void OnDestroy()
    {
        DATA.SHOP.ShopClosed -= OnShopClosed;
        DATA.HEALTH.HealthDepleted -= OnHealthDepleted;
        DATA.IN_GAME_EVENT.EventStarting -= OnEventStarting;
        DATA.IN_GAME_EVENT.EventFinished -= OnEventFinished;
        DATA.IN_GAME_EVENT.CampaignCompleted -= OnCampaignCompleted;
    }

    private void OnShopClosed()
    {
        DATA.GAME_STATUS.SetGameStatus(GAME_STATUS.RUNNING);
    }

    private void OnHealthDepleted()
    {
        DATA.GAME_STATUS.SetGameStatus(GAME_STATUS.SHOPPING);
    }

    private void OnEventStarting(InGameEventScriptableObject _)
    {
        DATA.GAME_STATUS.SetGameStatus(GAME_STATUS.PAUSED);
    }

    private void OnEventFinished()
    {
        DATA.GAME_STATUS.SetGameStatus(GAME_STATUS.RUNNING);
    }

    private void OnCampaignCompleted()
    {
        DATA.GAME_STATUS.SetGameStatus(GAME_STATUS.SHOPPING);
    }

    private void Start()
    {
        DATA.GAME_STATUS.SetGameStatus(_gameStatusAtStart);
    }
}
