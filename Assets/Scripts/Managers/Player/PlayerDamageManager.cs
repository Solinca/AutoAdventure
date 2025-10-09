using UnityEngine;

public class PlayerDamageManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _startingDamage = 1;

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
        if (item.ShopItemType == SHOP_ITEM_TYPE.DAMAGE)
        {
            DATA.DAMAGE.IncreaseDamage(item.ShopItemAmount);
        }
    }

    private void Start()
    {
        DATA.DAMAGE.IncreaseDamage(_startingDamage);
    }
}
