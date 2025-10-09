using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Settings | Shop Items")]
    [SerializeField] private ShopItemScriptableObject[] _shopItemList;

    private void Awake()
    {
        foreach (ShopItemScriptableObject item in _shopItemList)
        {
            item.CurrentNumberOfPurchase = 0;

            DATA.SHOP.AddItem(item);
        }

        DATA.SHOP.ItemBought += OnItemBought;
    }

    private void OnDestroy()
    {
        DATA.SHOP.ItemBought -= OnItemBought;
    }

    public void OnItemBought(ShopItemScriptableObject item)
    {
        DATA.SHOP.IncreaseNumberOfPurchase(item);
    }
}
