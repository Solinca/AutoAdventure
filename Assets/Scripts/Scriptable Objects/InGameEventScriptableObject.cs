using UnityEngine;

[CreateAssetMenu(fileName = "InGameEvent", menuName = "ScriptableObjects/InGameEvent", order = 1)]
public class InGameEventScriptableObject : ScriptableObject
{
    public string InGameEventName;
    public EVENT_TYPE InGameEventType;
}
