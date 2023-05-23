using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class MyInvenItem : MonoBehaviour
{
    //아이템 한칸 스크립트
    [SerializeField] Define.Item thisItem;
    public TMPro.TMP_Text _itemName;
    public Image _btnImage;

    public void SetItem(Define.Item item)
    {
        thisItem = item;
        _itemName.text = item.ItemName;

        if(item.image != null)
            _btnImage.sprite = item.image;
    }
    public void changItem()
    {
        Define.ItemCategory tempcate = thisItem.itemCategory;
        UserData.instance.mySaveData.changeItem(thisItem.itemCategory, thisItem.ItemIndex);
        print($"아이템이 {thisItem.ItemName} 으로 교체되었습니다");
    }
}
