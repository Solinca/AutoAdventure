using TMPro;
using UnityEngine;

public class HandleEventText : MonoBehaviour
{
    public void SetEventText(string text)
    {
        GetComponent<TextMeshProUGUI>().SetText(text);
    }
}
