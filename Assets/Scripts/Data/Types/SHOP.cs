using System.Collections.Generic;

public class SHOP_DATA
{
    public EVENT.GameEvent ShopClosed;

    public EVENT.ShopItemEvent ItemBought;

    // ------------------------------------------------ //

    public List<ShopItemScriptableObject> ShopItemList => _shopItemList;

    private readonly List<ShopItemScriptableObject> _shopItemList = new();

    public void AddItem(ShopItemScriptableObject item)
    {
        _shopItemList.Add(item);
    }

    public void IncreaseNumberOfPurchase(ShopItemScriptableObject item)
    {
        item.CurrentNumberOfPurchase++;
    }

    public bool CheckItemAvailability(ShopItemScriptableObject item)
    {
        return item.CurrentNumberOfPurchase < item.NumberOfAvailablePurchase;
    }
}
