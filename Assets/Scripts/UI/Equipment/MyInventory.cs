using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.UI;
using TMPro;

public class MyInventory : MonoBehaviour
{
    public static MyInventory instance;
    //하단 아이템들 관리
    public Transform ContentParent;
    public GameObject ItemPrefab;
    public GameObject InventoryItem;
    List<Item> tempItemList = new List<Item>();
    private void Start() {
        instance= this;
        ResetUpperInventory();
    }

    public void ShowMyItems(int index)
    {
        InventoryItem.SetActive(true);
        //위쪽 장비창도 바꿔줘야함
        ResetUpperInventory();

        //아랫쪽 인벤토리 보여주기
        ItemCategory desiredCategory = (ItemCategory)index;
        DeleteAllChildren(ContentParent);
        foreach (Item item in Managers.Data.AllitemList)
        {
            if (item.itemCategory == desiredCategory && !UserData.instance.mySaveData.equiping_Equipments_index.Contains(item.ItemIndex))
            {
                UserData.instance.mySaveData.equiping_Equipments_index.Sort();
                tempItemList.Add(item);
                GameObject go = Instantiate(ItemPrefab, ContentParent);
                go.GetComponent<MyInvenItem>().SetItem(item);
            }
        }
    }

    public void ResetUpperInventory()
    {
        for(int i=0;i<6;i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = System.Enum.GetName(typeof(ItemCategory), (ItemCategory)i) + "\n" +
            Managers.Data.LoadItembyIndex(UserData.instance.mySaveData.equiping_Equipments_index[i]).ItemName;
            transform.GetChild(i).GetChild(1).GetChild(0).GetComponent<Image>().sprite = 
            Managers.Data.LoadItembyIndex(UserData.instance.mySaveData.equiping_Equipments_index[i]).image;
        }
    }

    private void DeleteAllChildren(Transform parent)
    {
        int childCount = parent.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = parent.GetChild(i);
            Destroy(child.gameObject);
        }
    }
}
