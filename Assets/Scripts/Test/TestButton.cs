using UnityEngine;

public class TestButton : MonoBehaviour
{
    public void TakeOneDamage()
    {
        DATA.HEALTH.SetCurrentHealth(DATA.HEALTH.CurrentHealth - 1);
    }

    public void IncreaseMaxHeart()
    {
        DATA.HEALTH.IncreaseMaxHealth();
    }

    public void IncreaseGoldBy1()
    {
        DATA.GOLD.IncreaseCurrentGold();
    }

    public void IncreaseGoldBy5()
    {
        DATA.GOLD.IncreaseCurrentGold(5);
    }
}
