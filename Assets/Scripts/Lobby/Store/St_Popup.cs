using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Define;

public class St_Popup : MonoBehaviour
{
    [SerializeField] TMP_Text CateName;
    [SerializeField] GameObject ItemPrefab;
    [SerializeField] Transform content;
    List<Item> thisCategoryItems = new List<Item>();

    public void Set_PopUp(string name, ItemCategory _ItemCategory)
    {
        CateName.text = name;
        fillItems(_ItemCategory);
    } 

    void fillItems(ItemCategory _ItemCategory)
    {
        DestroyAllChildren(content);
        foreach(Item item in Managers.Data.AllitemList)
        {
            if(item.itemCategory == _ItemCategory)
                {
                    GameObject tempItem = Instantiate(ItemPrefab, content);
                    tempItem.GetComponent<St_Item>().SetItem(item);
                }
        }
    }

    public void DestroyAllChildren(Transform parent)
{
    for (int i = parent.childCount - 1; i >= 0; i--)
    {
        GameObject.Destroy(parent.GetChild(i).gameObject);
    }
}
}
