using UnityEngine;

public class HandleInGameEventChat : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _textContainer;
    [SerializeField] private HandleEventText _eventTextPrefab;

    private void Awake()
    {
        DATA.IN_GAME_EVENT.EventStarting += OnEventStarting;
        DATA.IN_GAME_EVENT.EventFinished += OnEventFinished;
        DATA.GAME_STATUS.CurrentGameStatusChanged += OnCurrentGameStatusChanged;
        DATA.IN_GAME_EVENT.ChatMessage += OnChatMessage;
    }

    private void OnDestroy()
    {
        DATA.IN_GAME_EVENT.EventStarting -= OnEventStarting;
        DATA.IN_GAME_EVENT.EventFinished -= OnEventFinished;
        DATA.GAME_STATUS.CurrentGameStatusChanged -= OnCurrentGameStatusChanged;
        DATA.IN_GAME_EVENT.ChatMessage -= OnChatMessage;
    }

    private void OnEventStarting(InGameEventScriptableObject igEvent)
    {
        gameObject.SetActive(true);
    }

    private void OnEventFinished()
    {
        ClearChatBox();
    }
    private void OnCurrentGameStatusChanged(GAME_STATUS gameStatus)
    {
        if (gameStatus == GAME_STATUS.SHOPPING)
        {
            ClearChatBox();
        }
    }

    private void OnChatMessage(string message)
    {
        Instantiate(_eventTextPrefab, _textContainer.transform).SetEventText(message);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void ClearChatBox()
    {
        foreach (var eventText in _textContainer.GetComponentsInChildren<HandleEventText>())
        {
            eventText.gameObject.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
