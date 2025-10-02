using UnityEngine;
using UnityEngine.UI;

public class HandleHeartSprite : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite _fullHeartSprite;
    [SerializeField] private Sprite _emptyHeartSprite;

    private Image _heartImageComponent;

    private void Awake()
    {
        _heartImageComponent = GetComponent<Image>();
    }

    public void DisplayFullHeart()
    {
        _heartImageComponent.sprite = _fullHeartSprite;
    }

    public void DisplayEmptyHeart()
    {
        _heartImageComponent.sprite = _emptyHeartSprite;
    }
}
