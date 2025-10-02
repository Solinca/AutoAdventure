using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _shopItemContainer;
    [SerializeField] private HandleShopItem _shopItemPrefab;

    [Header("Items")]
    [SerializeField] private ShopItemScriptableObject[] _shopItemList;

    EVENT.BuyItemEvent buyItemDelegate;

    private void Awake()
    {
        DATA.GAME_STATUS.CurrentGameStatusChanged += OnCurrentGameStatusChanged;
    }

    private void OnDestroy()
    {
        DATA.GAME_STATUS.CurrentGameStatusChanged -= OnCurrentGameStatusChanged;
    }

    private void Start()
    {
        buyItemDelegate = BuyItem;

        foreach (ShopItemScriptableObject item in _shopItemList)
        {
            Instantiate(_shopItemPrefab, _shopItemContainer.transform)
                .SetupShopItem(item.ShopItemName, item.ShopItemPrice, item.NumberOfAvailablePurchase, item.ShopItemType, buyItemDelegate);
        }
    }

    private void OnCurrentGameStatusChanged(GAME_STATUS status)
    {
        gameObject.SetActive(status == GAME_STATUS.SHOPPING);
    }

    private void BuyItem(SHOP_ITEM_TYPE type, int price)
    {
        DATA.GOLD.DecreaseCurrentGold(price);

        switch (type)
        {
            case SHOP_ITEM_TYPE.HEALTH:
                DATA.HEALTH.IncreaseMaxHealth();
                break;

            case SHOP_ITEM_TYPE.DAMAGE:
                break;

            case SHOP_ITEM_TYPE.LUCK:

                break;
        }
    }

    public void CloseShop()
    {
        DATA.GAME_STATUS.SetGameState(GAME_STATUS.RUNNING);
    }
}
