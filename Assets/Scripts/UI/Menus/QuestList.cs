using UnityEngine.UI;  
using UnityEngine;
using TMPro;
using static Define;
public class QuestList : MonoBehaviour
{
    public Image BackGround;
    public TMP_Text QuestGrade;
    public TMP_Text QuestName;
    public MonsterList ThisQuestMonster;

    public void SetQuest(MonsterList monster)
    {
        ThisQuestMonster = monster;
        QuestName.text = monster + " 토벌";
        if(monster == UserData.instance.mySaveData.Data_conquered+1)
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
        MonsterInfo.OpenInfoPopup(DataParsingMachine.Inst.AllMonList[(int)ThisQuestMonster]);
    }
}
