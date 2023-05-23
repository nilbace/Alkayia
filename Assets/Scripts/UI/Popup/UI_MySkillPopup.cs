using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_MySkillPopup : UI_Popup
{
    enum Buttons{
        HuntBTN,
        CloseBTN
    }
    enum Texts{
        
    }

    enum Images
    {
        parchmentImg
    }
    enum GameObjects
    {
        SkillScrollView
    }
    private void Start() {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        //Bind<TMP_Text>(typeof(Texts));
        //Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));
        
        GetButton((int)Buttons.HuntBTN).gameObject.AddUIEvent(Hunt);
        GetButton((int)Buttons.CloseBTN).gameObject.AddUIEvent(Close);

        Transform Content = Get<GameObject>((int)GameObjects.SkillScrollView).transform.GetChild(0).GetChild(0);

        foreach(Transform child in Content.transform)
            Managers.Resource.Destroy(child.gameObject);


        for(int i = 0; i<5;i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_OneSkillTree>(Content.transform).gameObject;
            UI_OneSkillTree invenItem = item.GetOrAddComponent<UI_OneSkillTree>();
            
            //invenItem.SetInfo($"장신구{i}번");
            //아이콘 정보 셋팅
        }
    }

    public void Hunt(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.BattleScene);
    }

    public void Close(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
        Managers.UI.ClosePopupUI();
    }
}
