using UnityEngine;

public class PlayerGoldManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _startingGold = 100;

    private void Awake()
    {
        DATA.SHOP.ItemBought += OnItemBought;
        DATA.GOLD.GoldGained += OnGoldGained;
    }

    private void OnDestroy()
    {
        DATA.SHOP.ItemBought -= OnItemBought;
        DATA.GOLD.GoldGained -= OnGoldGained;
    }

    private void OnItemBought(ShopItemScriptableObject item)
    {
        DATA.GOLD.DecreaseCurrentGold(item.ShopItemPrice);

        DATA.GOLD.CurrentGoldChanged.Invoke();
    }

    private void OnGoldGained(int amount)
    {
        IncreaseCurrentCold(amount);
    }

    private void Start()
    {
        IncreaseCurrentCold(_startingGold);
    }

    private void IncreaseCurrentCold(int amount)
    {
        DATA.GOLD.IncreaseCurrentGold(amount);

        DATA.GOLD.CurrentGoldChanged.Invoke();
    }
}
