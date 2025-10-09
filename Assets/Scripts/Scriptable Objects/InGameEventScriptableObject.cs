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
    public int Damage;

    [ConditionalProperty(EVENT_TYPE.FIGHT)]
    public int Health;

    [ConditionalProperty(EVENT_TYPE.FIGHT)]
    public int Gold;
}
