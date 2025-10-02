using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandleShopItem : MonoBehaviour
{
    [Header("TextFields")]
    [SerializeField] private TextMeshProUGUI _shopItemNameText;
    [SerializeField] private TextMeshProUGUI _shopItemPriceText;

    private Button _buyItemButton;

    private ShopItemScriptableObject item;

    private void Awake()
    {
        _buyItemButton = GetComponent<Button>();
    }

    public void SetupShopItem(ShopItemScriptableObject shopItem)
    {
        _shopItemNameText.text = shopItem.ShopItemName;
        _shopItemPriceText.text = shopItem.ShopItemPrice.ToString();

        _buyItemButton.onClick.AddListener(BuyItem);

        item = shopItem;
    }

    public void BuyItem()
    {
        DATA.SHOP.ItemBought.Invoke(item);

        _buyItemButton.interactable = DATA.SHOP.CheckItemAvailability(item);
    }
}
