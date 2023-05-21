using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    Transform ContentParent;
    private void Awake() {
        ContentParent = GameObject.FindGameObjectWithTag("MainUI").transform;
    }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Lobby;
    }

    public static void setQuests()
    {
        for(int i = UserData.instance.mySaveData.int_conqueredMonster+1; i >0 ; i--)
        {
            //GameObject listObject = Managers.Resource.Load<GameObject>()
            /* Instantiate(QuestList, Vector3.up, Quaternion.identity, ContentParent);
            listObject.GetComponent<QuestList>().SetQuest(i); */
        }

        for(int i = 0; i<5;i++)
        {
            /* GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(gridPanel.transform).gameObject;
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"장신구{i}번"); */
        }
    }

    public override void Clear()
    {
        
    }
}
