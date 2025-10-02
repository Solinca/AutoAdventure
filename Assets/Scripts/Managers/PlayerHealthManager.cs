using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _startingHealth = 3;

    private void Awake()
    {
        DATA.HEALTH.DamageTaken += OnDamageTaken;
        DATA.SHOP.ItemBought += OnItemBought;
    }

    private void OnDestroy()
    {
        DATA.HEALTH.DamageTaken -= OnDamageTaken;
        DATA.SHOP.ItemBought -= OnItemBought;
    }

    private void OnDamageTaken(int damage)
    {
        DATA.HEALTH.LoseHealth(damage);

        if (DATA.HEALTH.CurrentHealth <= 0)
        {
            DATA.HEALTH.HealthDepleted.Invoke();

            DATA.HEALTH.SetCurrentHealth(DATA.HEALTH.MaxHealth);
        }

        DATA.HEALTH.CurrentHealthChanged.Invoke();
    }

    private void OnItemBought(ShopItemScriptableObject item)
    {
        if (item.ShopItemType == SHOP_ITEM_TYPE.HEALTH)
        {
            IncreaseMaxHealth(item.ShopItemAmount);
        }
    }

    private void Start()
    {
        IncreaseMaxHealth(_startingHealth);
    }

    private void IncreaseMaxHealth(int amount)
    {
        DATA.HEALTH.IncreaseMaxHealth(amount);

        DATA.HEALTH.MaxHealthIncreased.Invoke(amount);

        DATA.HEALTH.SetCurrentHealth(DATA.HEALTH.CurrentHealth + amount);

        DATA.HEALTH.CurrentHealthChanged.Invoke();
    }
}
