using UnityEngine;

public class HandleShop : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _shopItemContainer;
    [SerializeField] private HandleShopItem _shopItemPrefab;

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
        foreach (ShopItemScriptableObject item in DATA.SHOP.ShopItemList)
        {
            Instantiate(_shopItemPrefab, _shopItemContainer.transform).SetupShopItem(item);
        }
    }

    private void OnCurrentGameStatusChanged(GAME_STATUS status)
    {
        gameObject.SetActive(status == GAME_STATUS.SHOPPING);
    }

    public void CloseShop()
    {
        DATA.SHOP.ShopClosed.Invoke();
    }
}
