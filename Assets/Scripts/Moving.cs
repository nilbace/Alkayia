using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    bool move, _combine;
    int _x2, _y2;
    Vector2 startpoz;
    float tilespacing;
    [SerializeField] RuntimeAnimatorController[] myControllers = new RuntimeAnimatorController[3];
    private void Start() {
        startpoz = BattleManager.instance.Zero_ZeroPoz;
        tilespacing = BattleManager.instance.Tilespacing;

        switch(EquipDatas.instance.boardSize)
        {
            case EquipDatas.BoardSize.Size4_4 :
            break;

            case EquipDatas.BoardSize.Size5_5 :
            break;

            case EquipDatas.BoardSize.Size6_6 :
            break;

            default :
            print("bug");
            break;
        }
    }
    void Update()
    {
        if(move)
        {
            Move(_x2, _y2, _combine);
        }
    }

    public void Move(int x2, int y2, bool combine)
    {
        move = true; _x2 = x2; _y2 = y2; _combine = combine;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(startpoz.x + tilespacing*x2 , startpoz.y + tilespacing*y2,0), 0.3f);

        if(transform.position == new Vector3(startpoz.x + tilespacing*x2 , startpoz.y + tilespacing*y2,0))
        {
            move = false;
            if(combine){ _combine=false; Destroy(gameObject);}
        }
    }
}
