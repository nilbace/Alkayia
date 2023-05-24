using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.Networking;
using System;

public class DataManager
{
    public List<Define.Item> AllitemList = new List<Define.Item>();
    public List<Define.Monster> AllMonsterList = new List<Monster>();
    public Define.Monster ThisQuestMonster = null;
    public Item LoadItembyIndex(int index)
    {
        Item temp = null;
        foreach (Item item in AllitemList)
        {
            if (item.ItemIndex == index)
            {
                temp = item;
            }
        }

        return temp;
    }

    public LydiaStat LydiaStat = new LydiaStat();

    void SettingMyStat()
    {
        MyEquipItems myEquipItems = UserData.instance.myEquipItems;
        //초기화

        LydiaStat.AttackPower = myEquipItems.EquipedAmplifier.itemStat;
        LydiaStat.HP = myEquipItems.EquipedBracelet.itemStat;
        LydiaStat.MyBoardSize = (BoardSize)myEquipItems.EquipedNecklace.itemStat;
        LydiaStat.MaxNum = myEquipItems.EquipedEarrings.itemStat;
    }
}
