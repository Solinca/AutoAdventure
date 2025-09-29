using TMPro;
using UnityEngine;

public class HandleShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _shopItemNameText;
    [SerializeField] private TextMeshProUGUI _shopItemPriceText;

    private int _
    private int maxNumberOfAvailablePurchase;

    public void SetupShopItem(string shopItemName, int shopItemPrice, int numberOfAvailablePurchase)
    {
        _shopItemNameText.text = shopItemName;
        _shopItemPriceText.text = shopItemPrice.ToString();

        maxNumberOfAvailablePurchase = numberOfAvailablePurchase;
    }

    public void BuyItem()
    {
        DATA.GOLD.DecreaseCurrentGold()
    }
}
