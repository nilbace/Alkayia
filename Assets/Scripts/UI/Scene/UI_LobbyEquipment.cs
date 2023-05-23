using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static Define;

public class UI_LobbyEquipment : UI_Base
{
    int checkCategory;
    private void Start() {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(ItemCategory));

        for(int i=0;i<6;i++)
        {
            if(GetGameObject(i) == null)
            {
                print("BindFailed");
            }
            GetGameObject(i).transform.GetChild(0).GetComponent<TMP_Text>().text = System.Enum.GetName(typeof(ItemCategory), (ItemCategory)i);
        }
    }

    public void ShowMyItems(int index)
    {
        List<Item> tempItemList = new List<Item>();
        //특정 카테고리 담을 컨테이너
        ItemCategory desiredCategory = (ItemCategory)index; 

        foreach (Item item in Managers.Data.AllitemList)
        {
            if (item.itemCategory == desiredCategory)
            {
                tempItemList.Add(item);
            }
        }

        foreach (Item item in tempItemList)
        {
            Debug.Log(item.ItemName);
        }
    }
}
