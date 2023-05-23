using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_OneSkillTree : UI_Base
{

    enum Images{
        MainIcon,
        
    }

    enum Buttons{
        FirstAtt,
        SecondAtt
    }

    string _name;

    private void Start() {
        Init();
    }

    public override void Init()
    {
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        //GetImage((int)Images.MainIcon) = 
        //아이콘 변경

        GetButton((int)Buttons.FirstAtt).gameObject.AddUIEvent(Att1);
        GetButton((int)Buttons.SecondAtt).gameObject.AddUIEvent(Att2);
    }

    public void Att1(PointerEventData data)
    {
        print("Attribute1 attached");
    }

    public void Att2(PointerEventData data)
    {
        print("Attribute2 attached");
    }

    public void Setinfo()
    {
        
    }
}
