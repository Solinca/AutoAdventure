using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private void Awake()
    {
        DATA.HEALTH.CurrentHealthChanged += OnCurrentHealthChanged;
    }

    private void OnDestroy()
    {
        DATA.HEALTH.CurrentHealthChanged -= OnCurrentHealthChanged;
    }

    private void OnCurrentHealthChanged(int currentHealth)
    {
        if (currentHealth == 0)
        {
            DATA.GAME_STATUS.SetGameState(GameStatus.GAME_STATE.SHOPPING);
        }
    }
}
