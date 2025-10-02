using UnityEngine;

public class TestButton : MonoBehaviour
{
    public void TakeOneDamage()
    {
        DATA.HEALTH.DamageTaken.Invoke(1);
    }

    public void IncreaseMaxHeart()
    {
        DATA.HEALTH.MaxHealthIncreased.Invoke(1);
    }

    public void IncreaseGoldBy1()
    {
        DATA.GOLD.GoldGained.Invoke(1);
    }

    public void IncreaseGoldBy5()
    {
        DATA.GOLD.GoldGained.Invoke(5);
    }
}
