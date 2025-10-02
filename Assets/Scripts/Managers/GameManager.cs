using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool _isPausedAtStart = false;
    [SerializeField] private int _startingHealth = 3;
    [SerializeField] private int _startingGold = 100;
    [SerializeField] private int _startingDamage = 1;
    [SerializeField] private int _startingLuck = 0;

    private void Start()
    {
        DATA.GAME_STATUS.SetGameState(_isPausedAtStart ? GAME_STATUS.PAUSED : GAME_STATUS.RUNNING);

        DATA.HEALTH.IncreaseMaxHealth(_startingHealth);

        DATA.GOLD.IncreaseCurrentGold(_startingGold);

        DATA.DAMAGE.IncreaseDamage(_startingDamage);

        DATA.LUCK.IncreaseLuck(_startingLuck);
    }
}
