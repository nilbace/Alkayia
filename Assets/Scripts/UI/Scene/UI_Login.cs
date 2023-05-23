using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UI_Login : UI_Scene
{
    enum Buttons
    {
        BtnGameStart,
        BtnSetting,
        BtnQuit
    }
    enum Texts
    {
        Title
    }

    private void Start() {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));  

        GetButton((int)Buttons.BtnGameStart).gameObject.AddUIEvent(StartGame);
    }


    public void StartGame(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Lobby);
    }

}
