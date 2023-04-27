using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Define;

public class St_Item : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemName;
    public TMP_Text itemStat;
    public TMP_Text itemInfos;

    public void SetItem(Item _item)
    {
        itemImage.sprite = _item.image;
        itemName.text = _item.ItemName;
        itemStat.text = "능력치 " + _item.itemStat;
        itemInfos.text = _item.itemInfo;
    }    
}
