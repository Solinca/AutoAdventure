using UnityEngine;
public class ConditionalPropertyAttribute : PropertyAttribute
{
    public EVENT_TYPE condition;

    public ConditionalPropertyAttribute(EVENT_TYPE type)
    {
        condition = type;
    }
}
