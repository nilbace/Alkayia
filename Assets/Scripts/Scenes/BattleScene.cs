using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : BaseScene
{
    private void Awake() {
        Init();
    }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.BattleScene;
        Managers.Data.Init();   
    }

    public override void Clear()
    {
        
    }

}
