using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    private void Start() {
        Init();
    }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;
        
    }

   
    public override void Clear()
    {
        
    }


}
