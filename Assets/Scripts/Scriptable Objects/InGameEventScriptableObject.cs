using UnityEngine;

[CreateAssetMenu(fileName = "InGameEvent", menuName = "ScriptableObjects/InGameEvent", order = 1)]
public class InGameEventScriptableObject : ScriptableObject
{
    public string InGameEventName;
    public Sprite InGameEventSprite;
    public Color InGameEventColor;

    [Space]

    public EVENT_TYPE InGameEventType;

    [Space]

    [ConditionalProperty(EVENT_TYPE.FIGHT)]
    public int Damage = 0;

    [ConditionalProperty(EVENT_TYPE.FIGHT)]
    public int Health = 0;

    [ConditionalProperty(EVENT_TYPE.FIGHT)]
    public int Gold = 0;
}
