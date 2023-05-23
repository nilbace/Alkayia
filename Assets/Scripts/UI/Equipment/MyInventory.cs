using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.UI;
using TMPro;

public class MyInventory : MonoBehaviour
{
    //하단 아이템들 관리
    public Transform ContentParent;
    public GameObject ItemPrefab;
    List<Item> tempItemList = new List<Item>();
    private void Start() {
        for(int i=0;i<6;i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = System.Enum.GetName(typeof(ItemCategory), (ItemCategory)i);
        }
    }

    public void ShowMyItems(int index)
    {
        ItemCategory desiredCategory = (ItemCategory)index;
        DeleteAllChildren(ContentParent);
        foreach (Item item in Managers.Data.AllitemList)
        {
            if (item.itemCategory == desiredCategory)
            {
                tempItemList.Add(item);
                GameObject go = Instantiate(ItemPrefab, ContentParent);
                go.GetComponent<MyInvenItem>().SetItem(item);
            }
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
