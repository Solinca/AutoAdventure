using TMPro;
using UnityEngine;

public class HandleGoldContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldAmountText;

    private void Awake()
    {
        DATA.GOLD.CurrentGoldChanged += OnCurrentGoldChanged;
    }

    private void OnDestroy()
    {
        DATA.GOLD.CurrentGoldChanged -= OnCurrentGoldChanged;
    }

    private void OnCurrentGoldChanged()
    {
        _goldAmountText.text = DATA.GOLD.CurrentGold.ToString();
    }
}
