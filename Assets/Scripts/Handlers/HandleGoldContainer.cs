using TMPro;
using UnityEngine;

public class HandleGoldContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldAmount;

    private void Start()
    {
        Data.CurrentGoldChanged += OnCurrentGoldChanged;
    }

    private void OnDestroy()
    {
        Data.CurrentGoldChanged -= OnCurrentGoldChanged;
    }

    private void OnCurrentGoldChanged()
    {
        _goldAmount.text = Data.CurrentGold.ToString();
    }
}
