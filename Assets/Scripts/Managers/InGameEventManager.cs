using UnityEngine;
using System.Collections.Generic;

public class InGameEventManager : MonoBehaviour
{
    [Header("In Game Events")]
    [SerializeField] private List<InGameEventScriptableObject> _inGameEventList;

    [Header("Settings")]
    [SerializeField] private float _timeBetweenEvents;
    [SerializeField] private int _numberOfEventToGenerate;

    private int eventIndex = 0;

    private readonly List<InGameEventScriptableObject> generatedEventList = new();

    private void Awake()
    {
        DATA.GAME_STATUS.CurrentGameStatusChanged += OnCurrentGameStatusChanged;
    }

    private void OnDestroy()
    {
        DATA.GAME_STATUS.CurrentGameStatusChanged -= OnCurrentGameStatusChanged;
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

    private void Start()
    {
        GenerateEventList();
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
        DATA.IN_GAME_EVENT.EventStarting.Invoke();

        InGameEventScriptableObject triggeredEvent = generatedEventList[eventIndex];

        Debug.Log(triggeredEvent.InGameEventName);
        Debug.Log(triggeredEvent.InGameEventType);

        eventIndex++;

        if (eventIndex >= _numberOfEventToGenerate)
        {
            DATA.IN_GAME_EVENT.CampaignCompleted.Invoke();
        }
        else
        {
            DATA.IN_GAME_EVENT.EventFinished.Invoke();
        }
    }
}
