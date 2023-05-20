using UnityEngine.UI;  
using UnityEngine;
using TMPro;
using static Define;
public class QuestList : MonoBehaviour
{
    public Image BackGround;
    public TMP_Text QuestGrade;
    public TMP_Text QuestName;
    public Monster thisQuestMonster;
    public int ThisQuestMonsterIndex;

    public void SetQuest(int monIndex)
    {
        ThisQuestMonsterIndex = monIndex;
        thisQuestMonster = DataParsingMachine.Inst.AllMonList[monIndex];
        QuestName.text = DataParsingMachine.Inst.AllMonList[monIndex].name + " 토벌";
        if(monIndex == UserData.instance.mySaveData.int_conqueredMonster+1)
        {
            BackGround.color = Color.yellow;
            QuestGrade.text = "메인 퀘스트";
        }
        else
        {
            BackGround.color = Color.magenta;
            QuestGrade.text = "반복 퀘스트";
        }
    }

    public void StartQuest()
    {
        Managers.UI.ShowPopupUI<UI_MonsterInfoPopup>();
        UserData.instance.SetMonster(thisQuestMonster);
    }
}
