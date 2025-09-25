using UnityEngine;

public class HandleHeartContainer : MonoBehaviour
{
    [SerializeField] private HandleHeartSprite _heart;

    private void Awake()
    {
        Data.MaxHealthIncreased += OnMaxHealthIncreased;
        Data.CurrentHealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        Data.MaxHealthIncreased -= OnMaxHealthIncreased;
        Data.CurrentHealthChanged -= OnHealthChanged;
    }

    private void OnMaxHealthIncreased()
    {
        Instantiate(_heart, transform);

        RedrawHealthBar();
    }

    private void OnHealthChanged(int _)
    {
        RedrawHealthBar();
    }

    private void RedrawHealthBar()
    {
        for (int i = 0; i < Data.MaxHealth; i++)
        {
            if (i < Data.CurrentHealth)
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
