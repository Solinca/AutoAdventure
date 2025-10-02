using UnityEngine;
using System.Collections.Generic;

public class HandleHeartContainer : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private HandleHeartSprite _heartPrefab;

    private readonly List<HandleHeartSprite> heartList = new();

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
        heartList.Add(Instantiate(_heartPrefab, transform));

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
                heartList[i].DisplayFullHeart();
            }
            else
            {
                heartList[i].DisplayEmptyHeart();
            }
        }
    }
}
