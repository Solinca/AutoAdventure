using UnityEngine;
using UnityEngine.UI;

public class HandleHeartSprite : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite _fullHeartSprite;
    [SerializeField] private Sprite _emptyHeartSprite;

    private Image heartImageComponent;

    private void Awake()
    {
        heartImageComponent = GetComponent<Image>();
    }

    public void DisplayFullHeart()
    {
        heartImageComponent.sprite = _fullHeartSprite;
    }

    public void DisplayEmptyHeart()
    {
        heartImageComponent.sprite = _emptyHeartSprite;
    }
}
