using UnityEngine;

public class HandleHeartContainer : MonoBehaviour
{
    [SerializeField] private HandleHeartSprite _heartComponent;

    private void Awake()
    {
        DATA.HEALTH.MaxHealthIncreased += OnMaxHealthIncreased;
        DATA.HEALTH.CurrentHealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        DATA.HEALTH.MaxHealthIncreased -= OnMaxHealthIncreased;
        DATA.HEALTH.CurrentHealthChanged -= OnHealthChanged;
    }

    private void OnMaxHealthIncreased()
    {
        Instantiate(_heartComponent, transform);

        RedrawHealthBar();
    }

    private void OnHealthChanged(int _)
    {
        RedrawHealthBar();
    }

    private void RedrawHealthBar()
    {
        for (int i = 0; i < DATA.HEALTH.MaxHealth; i++)
        {
            if (i < DATA.HEALTH.CurrentHealth)
            {
                transform.GetComponentsInChildren<HandleHeartSprite>()[i].DisplayFullHeart();
            }
            else
            {
                transform.GetComponentsInChildren<HandleHeartSprite>()[i].DisplayEmptyHeart();
            }
        }
    }
}
