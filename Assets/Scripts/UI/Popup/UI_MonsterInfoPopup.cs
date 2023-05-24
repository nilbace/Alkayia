using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_MonsterInfoPopup : UI_Popup
{
    enum Buttons{
        HuntBTN,
        CloseBTN
    }
    enum Texts{
        MonNameTMP,
        InfoTMP,
    }

    enum Images
    {
        parchmentImg,
        MonPortrait
    }
    bool isInited = false;

    private void OnEnable() {
        if(isInited)
            SetInfo();
    }
    private void Start() {
        Init();
        OnEnable();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        
        GetButton((int)Buttons.HuntBTN).gameObject.AddUIEvent(Hunt);
        GetButton((int)Buttons.CloseBTN).gameObject.AddUIEvent(Close);
        isInited = true;
    }

    public void Hunt(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_MySkillPopup>();
    }

    public void Close(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
    }

    void SetInfo()
    {
        Define.Monster temp = Managers.Data.ThisQuestMonster;
        GetText((int)Texts.InfoTMP).text = temp.boardExplanation;
        GetText((int)Texts.MonNameTMP).text = temp.MonName;
        GetImage((int)Images.MonPortrait).sprite = temp.image;
    }
}
