using UnityEngine;
using UnityEngine.UI;

public class HandleHeartSprite : MonoBehaviour
{
    [SerializeField] private Image _heartImageComponent;
    [SerializeField] private Sprite _fullHeartSprite;
    [SerializeField] private Sprite _emptyHeartSprite;

    public void DisplayFullHeart()
    {
        _heartImageComponent.sprite = _fullHeartSprite;
    }

    public void DisplayEmptyHeart()
    {
        _heartImageComponent.sprite = _emptyHeartSprite;
    }
}
