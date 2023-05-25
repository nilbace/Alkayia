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
    public TMPro.TMP_Text _itemStat;
    public Image _btnImage;

    public void SetItem(Define.Item item)
    {
        thisItem = item;
        _itemName.text = item.ItemName;
        _itemStat.text = "스텟 : " + item.itemStat;

        if(item.image != null)
            _btnImage.sprite = item.image;
    }
    public void changItem()
    {
        UserData.instance.mySaveData.changeItem(thisItem.itemCategory, thisItem.ItemIndex);

        //인벤토리 닫기
        print(transform.parent.parent.parent.name);
        transform.parent.parent.parent.gameObject.SetActive(false);
        MyInventory.instance.ShowMyItems((int)thisItem.itemCategory);
    }
}
