using UnityEngine;

public class TestButton : MonoBehaviour
{
    public void TakeOneDamage()
    {
        Data.SetCurrentHealth(Data.CurrentHealth - 1);
    }

    public void IncreaseMaxHeart()
    {
        Data.IncreaseMaxHealth();
    }

    public void IncreaseGoldBy1()
    {
        Data.IncreaseCurrentGold();
    }

    public void IncreaseGoldBy5()
    {
        Data.IncreaseCurrentGold(5);
    }
}
