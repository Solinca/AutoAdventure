using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/ShopItem", order = 1)]
public class ShopItemScriptableObject : ScriptableObject
{
    public string ShopItemName;
    public int ShopItemPrice;
    public int NumberOfAvailablePurchase;
    public SHOP_ITEM_TYPE ShopItemType;
}
