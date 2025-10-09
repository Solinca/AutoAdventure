using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _startingHealth = 3;
    [SerializeField] private float _timeToWaitAtDeath = 3;

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

        DATA.HEALTH.CurrentHealthChanged.Invoke();

        if (DATA.HEALTH.CurrentHealth <= 0)
        {
            DATA.IN_GAME_EVENT.ChatMessage.Invoke("<color=#" + DATA.IN_GAME_EVENT.PLAYER_COLOR + ">Player</color> died :(");

            Invoke(nameof(DelayDeath), DATA.HEALTH.TIME_TO_WAIT_AT_DEATH);
        }
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

        DATA.HEALTH.TIME_TO_WAIT_AT_DEATH = _timeToWaitAtDeath;
    }

    private void IncreaseMaxHealth(int amount)
    {
        DATA.HEALTH.IncreaseMaxHealth(amount);

        DATA.HEALTH.MaxHealthIncreased.Invoke(amount);

        DATA.HEALTH.SetCurrentHealth(DATA.HEALTH.CurrentHealth + amount);

        DATA.HEALTH.CurrentHealthChanged.Invoke();
    }

    private void DelayDeath()
    {
        DATA.HEALTH.HealthDepleted.Invoke();

        DATA.HEALTH.SetCurrentHealth(DATA.HEALTH.MaxHealth);

        DATA.HEALTH.CurrentHealthChanged.Invoke();
    }
}
