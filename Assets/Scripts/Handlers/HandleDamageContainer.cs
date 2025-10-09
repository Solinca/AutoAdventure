using TMPro;
using UnityEngine;

public class HandleDamageContainer : MonoBehaviour
{
    [Header("TextFields")]
    [SerializeField] private TextMeshProUGUI _damageAmountText;

    private void Awake()
    {
        DATA.DAMAGE.CurrentDamageChanged += OnCurrentDamageChanged;
    }

    private void OnDestroy()
    {
        DATA.DAMAGE.CurrentDamageChanged -= OnCurrentDamageChanged;
    }

    private void OnCurrentDamageChanged()
    {
        _damageAmountText.text = DATA.DAMAGE.CurrentDamage.ToString();
    }
}
