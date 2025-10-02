using UnityEngine;

public class GameStatusManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GAME_STATUS _gameStatusAtStart = GAME_STATUS.RUNNING;

    private void Awake()
    {
        DATA.SHOP.ShopClosed += OnShopClosed;
        DATA.HEALTH.HealthDepleted += OnHealthDepleted;
    }

    private void OnDestroy()
    {
        DATA.SHOP.ShopClosed -= OnShopClosed;
        DATA.HEALTH.HealthDepleted -= OnHealthDepleted;
    }

    private void OnShopClosed()
    {
        DATA.GAME_STATUS.SetGameStatus(GAME_STATUS.RUNNING);
    }

    private void OnHealthDepleted()
    {
        DATA.GAME_STATUS.SetGameStatus(GAME_STATUS.SHOPPING);
    }

    private void Start()
    {
        DATA.GAME_STATUS.SetGameStatus(_gameStatusAtStart);
    }
}
