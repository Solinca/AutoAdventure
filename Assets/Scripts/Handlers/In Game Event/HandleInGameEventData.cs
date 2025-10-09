using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandleInGameEventData : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _inGameEventStatsContainer;

    [Header("Sprites")]
    [SerializeField] private Image _inGameEventSprite;

    [Header("TextFields")]
    [SerializeField] private TextMeshProUGUI _inGameEventHealthText;
    [SerializeField] private TextMeshProUGUI _inGameEventDamageText;

    private void Awake()
    {
        DATA.IN_GAME_EVENT.EventStarting += OnEventStarting;
        DATA.IN_GAME_EVENT.EventFinished += OnEventFinished;
        DATA.HEALTH.HealthDepleted += OnHealthDepleted;
    }

    private void OnDestroy()
    {
        DATA.IN_GAME_EVENT.EventStarting -= OnEventStarting;
        DATA.IN_GAME_EVENT.EventFinished -= OnEventFinished;
        DATA.HEALTH.HealthDepleted -= OnHealthDepleted;
    }

    private void OnEventStarting(InGameEventScriptableObject igEvent)
    {
        gameObject.SetActive(true);

        _inGameEventSprite.sprite = igEvent.InGameEventSprite;

        _inGameEventStatsContainer.SetActive(igEvent.InGameEventType == EVENT_TYPE.FIGHT);

        _inGameEventHealthText.SetText(igEvent.Health.ToString());
        _inGameEventDamageText.SetText(igEvent.Damage.ToString());
    }

    private void OnEventFinished()
    {
        gameObject.SetActive(false);
    }

    private void OnHealthDepleted()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
