using UnityEngine;
using UnityEngine.UI;

public class HandleInGameEventSprite : MonoBehaviour
{
    private Image inGameEventSprite;

    private void Awake()
    {
        DATA.IN_GAME_EVENT.EventStarting += OnEventStarting;
        DATA.IN_GAME_EVENT.EventFinished += OnEventFinished;
        DATA.GAME_STATUS.CurrentGameStatusChanged += OnCurrentGameStatusChanged;
    }

    private void OnDestroy()
    {
        DATA.IN_GAME_EVENT.EventStarting -= OnEventStarting;
        DATA.IN_GAME_EVENT.EventFinished -= OnEventFinished;
        DATA.GAME_STATUS.CurrentGameStatusChanged -= OnCurrentGameStatusChanged;
    }

    private void OnEventStarting(InGameEventScriptableObject igEvent)
    {
        inGameEventSprite.enabled = true;

        inGameEventSprite.sprite = igEvent.InGameEventSprite;
    }

    private void OnEventFinished()
    {
        inGameEventSprite.enabled = false;
    }

    private void OnCurrentGameStatusChanged(GAME_STATUS gameStatus)
    {
        if (gameStatus == GAME_STATUS.SHOPPING)
        {
            inGameEventSprite.enabled = false;
        }
    }

    private void Start()
    {
        inGameEventSprite = GetComponent<Image>();

        inGameEventSprite.enabled = false;
    }
}
