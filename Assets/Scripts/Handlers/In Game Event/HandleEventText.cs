using TMPro;
using UnityEngine;

public class HandleEventText : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _eventText;

    private void Start()
    {
        _eventText = GetComponent<TextMeshProUGUI>();
    }

    public void SetEventText(string text)
    {
        _eventText.SetText(text);
    }
}
