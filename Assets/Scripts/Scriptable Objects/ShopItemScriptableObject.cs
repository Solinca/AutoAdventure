using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/Shop", order = 1)]
public class ShopItemScriptableObject : ScriptableObject
{
    public HandleShopItem ShopItemPrefab;
    public string ShopItemName;
    public int ShopItemPrice;
    public int NumberOfAvailablePurchase;
}