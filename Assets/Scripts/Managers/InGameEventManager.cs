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

    private List<InGameEventScriptableObject> generatedEventList;

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
    }

    private void Start()
    {
        GenerateEventList();
    }

    private void GenerateEventList()
    {
        for (int i = 0; i < _numberOfEventToGenerate; i++)
        {
            generatedEventList.Add(_inGameEventList[Random.Range(0, _inGameEventList.Count)]);
        }
    }

    private void TriggerEvent()
    {
        //InGameEventScriptableObject triggeredEvent = generatedEventList[eventIndex];
    }
}
