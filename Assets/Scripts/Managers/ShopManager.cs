using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject _shopItemContainer;
    [SerializeField] private ShopItemScriptableObject[] _shopItems;

    private void Start()
    {
        foreach (ShopItemScriptableObject item in _shopItems)
        {
            HandleShopItem shopItem = Instantiate(item.ShopItemPrefab, _shopItemContainer.transform);

            shopItem.SetupShopItem(item.ShopItemName, item.ShopItemPrice, item.NumberOfAvailablePurchase);
        }
    }
}
