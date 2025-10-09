using UnityEngine;

public class PlayerLuckManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _startingLuck = 0;

    private void Awake()
    {
        DATA.SHOP.ItemBought += OnItemBought;
    }

    private void OnDestroy()
    {
        DATA.SHOP.ItemBought -= OnItemBought;
    }

    private void OnItemBought(ShopItemScriptableObject item)
    {
        if (item.ShopItemType == SHOP_ITEM_TYPE.LUCK)
        {
            DATA.LUCK.IncreaseLuck(item.ShopItemAmount);
        }
    }

    private void Start()
    {
        DATA.LUCK.IncreaseLuck(_startingLuck);
    }
}
