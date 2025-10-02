using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool _isPausedAtStart = false;
    [SerializeField] private int _startingHealth = 3;
    [SerializeField] private int _startingGold = 100;

    private void Start()
    {
        DATA.GAME_STATUS.SetGameState(_isPausedAtStart ? GAME_STATUS.PAUSED : GAME_STATUS.RUNNING);

        for (int i = 0; i < _startingHealth; i++)
        {
            DATA.HEALTH.IncreaseMaxHealth();
        }

        DATA.HEALTH.SetCurrentHealth(_startingHealth);

        DATA.GOLD.IncreaseCurrentGold(_startingGold);
    }
}
