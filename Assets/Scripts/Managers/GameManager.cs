using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isPaused;
    [SerializeField] private int _startingHealth;
    [SerializeField] private int _startingGold;

    private void Start()
    {
        DATA.GAME_STATUS.SetGameState(GameStatus.GAME_STATE.RUNNING);

        for (int i = 0; i < _startingHealth; i++)
        {
            DATA.HEALTH.IncreaseMaxHealth();
        }

        DATA.HEALTH.SetCurrentHealth(_startingHealth);

        DATA.GOLD.IncreaseCurrentGold(_startingGold);
    }
}
