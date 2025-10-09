using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class InGameEventManager : MonoBehaviour
{
    [Header("In Game Events")]
    [SerializeField] private List<InGameEventScriptableObject> _inGameEventList;

    [Header("Settings")]
    [SerializeField] private float _timeBetweenEvents;
    [SerializeField] private int _numberOfEventToGenerate;
    [SerializeField] private float _timeBetweenEventSteps;
    [SerializeField] private float _timeToWaitOnEventComplete;
    [SerializeField] private Color _playerNameColor;
    [SerializeField] private Color _damageColor;
    [SerializeField] private Color _goldColor;

    private int eventIndex = 0;

    private readonly List<InGameEventScriptableObject> generatedEventList = new();

    private void Awake()
    {
        DATA.GAME_STATUS.CurrentGameStatusChanged += OnCurrentGameStatusChanged;
        DATA.IN_GAME_EVENT.EventFinished += OnEventFinished;
    }

    private void OnDestroy()
    {
        DATA.GAME_STATUS.CurrentGameStatusChanged -= OnCurrentGameStatusChanged;
        DATA.IN_GAME_EVENT.EventFinished -= OnEventFinished;
    }

    private void OnCurrentGameStatusChanged(GAME_STATUS status)
    {
        if (status == GAME_STATUS.RUNNING)
        {
            Invoke(nameof(TriggerEvent), _timeBetweenEvents);
        }
        else if (status == GAME_STATUS.SHOPPING)
        {
            GenerateEventList();

            eventIndex = 0;
        }
    }

    private void OnEventFinished()
    {
        eventIndex++;

        if (eventIndex >= _numberOfEventToGenerate)
        {
            DATA.IN_GAME_EVENT.CampaignCompleted.Invoke();
        }
    }

    private void Start()
    {
        GenerateEventList();

        DATA.IN_GAME_EVENT.TIME_BETWEEN_EVENT_STEP = _timeBetweenEventSteps;
        DATA.IN_GAME_EVENT.TIME_TO_WAIT_ON_COMPLETE = _timeToWaitOnEventComplete;

        DATA.IN_GAME_EVENT.PLAYER_COLOR = _playerNameColor.ToHexString();
        DATA.IN_GAME_EVENT.DAMAGE_COLOR = _damageColor.ToHexString();
        DATA.IN_GAME_EVENT.GOLD_COLOR = _goldColor.ToHexString();
    }

    private void GenerateEventList()
    {
        generatedEventList.Clear();

        for (int i = 0; i < _numberOfEventToGenerate; i++)
        {
            generatedEventList.Add(_inGameEventList[Random.Range(0, _inGameEventList.Count)]);
        }
    }

    private void TriggerEvent()
    {
        DATA.IN_GAME_EVENT.EventStarting.Invoke(generatedEventList[eventIndex]);
    }
}
