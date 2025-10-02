using TMPro;
using UnityEngine;

public class HandleGoldContainer : MonoBehaviour
{
    [Header("TextFields")]
    [SerializeField] private TextMeshProUGUI _goldAmountText;

    private void Awake()
    {
        DATA.GOLD.CurrentGoldChanged += OnCurrentGoldChanged;
    }

    private void OnDestroy()
    {
        DATA.GOLD.CurrentGoldChanged -= OnCurrentGoldChanged;
    }

    private void OnCurrentGoldChanged(int goldAmount)
    {
        _goldAmountText.text = goldAmount.ToString();
    }
}
