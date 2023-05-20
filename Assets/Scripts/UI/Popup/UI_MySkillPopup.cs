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
    }

    public void Hunt(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.BattleScene);
    }

    public void Close(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
    }
}
