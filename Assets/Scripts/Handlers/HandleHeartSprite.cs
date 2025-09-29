using UnityEngine;
using UnityEngine.UI;

public class HandleHeartSprite : MonoBehaviour
{
    [SerializeField] private Image _heartImage;
    [SerializeField] private Sprite _fullHeartSprite;
    [SerializeField] private Sprite _emptyHeartSprite;

    public void DisplayFullHeart()
    {
        _heartImage.sprite = _fullHeartSprite;
    }

    public void DisplayEmptyHeart()
    {
        _heartImage.sprite = _emptyHeartSprite;
    }
}
