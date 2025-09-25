using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isPaused;
    [SerializeField] private int _startingHealth;

    private void Start()
    {
        Data.SetIsPaused(_isPaused);

        for (int i = 0; i < _startingHealth; i++)
        {
            Data.IncreaseMaxHealth();
        }

        Data.SetCurrentHealth(_startingHealth);
    }
}
