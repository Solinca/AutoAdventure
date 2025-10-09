using Unity.VisualScripting;
using UnityEngine;

public class FightEventManager : MonoBehaviour
{
    private bool isPlayerTurn = true;

    private string monsterName = "";
    private string monsterColor = "";
    private int monsterHealth = 0;
    private int monsterDamage = 0;
    private int monsterGold = 0;

    private void Awake()
    {
        DATA.IN_GAME_EVENT.EventStarting += OnEventStarting;
    }

    private void OnDestroy()
    {
        DATA.IN_GAME_EVENT.EventStarting -= OnEventStarting;
    }

    private void OnEventStarting(InGameEventScriptableObject igEvent)
    {
        if (igEvent.InGameEventType == EVENT_TYPE.FIGHT)
        {
            DATA.IN_GAME_EVENT.ChatMessage.Invoke(igEvent.InGameEventName + " appeared!");

            monsterName = igEvent.InGameEventName;
            monsterColor = igEvent.InGameEventColor.ToHexString();
            monsterHealth = igEvent.Health;
            monsterDamage = igEvent.Damage;
            monsterGold = igEvent.Gold;

            Invoke(nameof(ProcessNextStep), DATA.IN_GAME_EVENT.TIME_BETWEEN_EVENT_STEP);
        }
    }

    private void ProcessNextStep()
    {
        if (isPlayerTurn)
        {
            monsterHealth -= DATA.DAMAGE.CurrentDamage;

            DATA.IN_GAME_EVENT.ChatMessage.Invoke("<color=#" + DATA.IN_GAME_EVENT.PLAYER_COLOR + ">Player</color> dealt <color=#" + DATA.IN_GAME_EVENT.DAMAGE_COLOR + ">" + DATA.DAMAGE.CurrentDamage + " damage</color> to <color=#" + monsterColor + ">" + monsterName + "</color>");

            if (monsterHealth <= 0)
            {
                DATA.IN_GAME_EVENT.ChatMessage.Invoke("<color=#" + monsterColor + ">" + monsterName + "</color> has been defeated!");

                DATA.IN_GAME_EVENT.ChatMessage.Invoke("<color=#" + DATA.IN_GAME_EVENT.PLAYER_COLOR + ">Player</color> received <color=#" + DATA.IN_GAME_EVENT.GOLD_COLOR + ">" + monsterGold + " gold</color>");

                DATA.GOLD.GoldGained.Invoke(monsterGold);

                Invoke(nameof(CompleteEventWithSucess), DATA.IN_GAME_EVENT.TIME_TO_WAIT_ON_COMPLETE);

                return;
            }
        }
        else
        {
            DATA.IN_GAME_EVENT.ChatMessage.Invoke("<color=#" + monsterColor + ">" + monsterName + "</color> dealt <color=#" + DATA.IN_GAME_EVENT.DAMAGE_COLOR + ">" + monsterDamage + " damage</color> to <color=#" + DATA.IN_GAME_EVENT.PLAYER_COLOR + ">Player</color>");

            DATA.HEALTH.DamageTaken.Invoke(monsterDamage);

            if (DATA.HEALTH.CurrentHealth <= 0)
            {
                isPlayerTurn = true;

                return;
            }
        }

        isPlayerTurn = !isPlayerTurn;

        Invoke(nameof(ProcessNextStep), DATA.IN_GAME_EVENT.TIME_BETWEEN_EVENT_STEP);
    }

    private void CompleteEventWithSucess()
    {
        DATA.IN_GAME_EVENT.EventFinished.Invoke();

        isPlayerTurn = true;
    }
}
