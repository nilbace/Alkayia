using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UI_QuestList : UI_Base
{
    enum Images{
        BackGround,
    }

    public TMP_Text MonsterName;
    public TMP_Text QuestType;
    public Button Background;

    Define.Monster _thisquestMon;
    bool _isMainMon;

    string _name;

    private void Start() {
        Init();
    }

    public override void Init()
    {
        SetthisQuest();
    }

    public void Setinfo(bool isMain ,Define.Monster monster)
    {
        _isMainMon = isMain;
        _thisquestMon = monster;
    }

    void SetthisQuest()
    {
        MonsterName.text = _thisquestMon.name;
        if(_isMainMon)
        {
            QuestType.text = "메인 퀘스트";
            Background.image.color = Color.magenta;
        }
        else
        {
            QuestType.text = "반복 퀘스트";
            Background.image.color = Color.yellow;
        }
    }
    
    public void QuestListClicked()
    {
        showMonsterInfo(null);
    }

    public void showMonsterInfo(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_MonsterInfoPopup>();
        Managers.Data.ThisQuestMonster = _thisquestMon;
    }
}
