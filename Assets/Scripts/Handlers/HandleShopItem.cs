using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandleShopItem : MonoBehaviour
{
    [Header("TextFields")]
    [SerializeField] private TextMeshProUGUI _shopItemNameText;
    [SerializeField] private TextMeshProUGUI _shopItemPriceText;

    private int itemPrice;
    private int currentNumberOfAvailablePurchase = 0;
    private int maxNumberOfAvailablePurchase;
    private SHOP_ITEM_TYPE itemType;
    private EVENT.BuyItemEvent buyItemDelegate;

    private Button _shopItem;

    private void Awake()
    {
        _shopItem = GetComponent<Button>();
    }

    public void SetupShopItem(string shopItemName, int shopItemPrice, int numberOfAvailablePurchase, SHOP_ITEM_TYPE shopItemType, EVENT.BuyItemEvent globalDelegate)
    {
        _shopItemNameText.text = shopItemName;
        _shopItemPriceText.text = shopItemPrice.ToString();

        _shopItem.onClick.AddListener(BuyItem);

        itemType = shopItemType;
        itemPrice = shopItemPrice;
        buyItemDelegate = globalDelegate;
        maxNumberOfAvailablePurchase = numberOfAvailablePurchase;
    }

    public void BuyItem()
    {
        if (currentNumberOfAvailablePurchase < maxNumberOfAvailablePurchase)
        {
            buyItemDelegate(itemType, itemPrice);

            currentNumberOfAvailablePurchase++;
        }
    }
}
