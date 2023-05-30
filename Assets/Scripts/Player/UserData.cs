using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using static Define;

public class UserData : MonoBehaviour
{
    public static UserData instance;
    private void Awake() {
    if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    LoadPlayerDatafromJson();
}

    public SaveData mySaveData;
    public List<Item> My_purchased_items = new List<Item>();
    public MyEquipItems myEquipItems = new MyEquipItems();
    



    [ContextMenu("데이터 저장")]
    public void SavePlayerDataToJson()
    {
        string path;
        if (Application.platform == RuntimePlatform.Android)
        {
            path = Path.Combine(Application.persistentDataPath, "playerData.json");
        }
        else
        {
            path = Path.Combine(Application.dataPath, "playerData.json");
        }
        string jsonData = JsonUtility.ToJson(mySaveData, true);

        FileStream fileStream = new FileStream(path, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    [ContextMenu("데이터 불러오기")]
    public void LoadPlayerDatafromJson()
    {
        string path;
        if (Application.platform == RuntimePlatform.Android)
        {
            path = Path.Combine(Application.persistentDataPath, "playerData.json");
        }
        else
        {
            path = Path.Combine(Application.dataPath, "playerData.json");
        }

        if(!File.Exists(path))
        {
            mySaveData = new SaveData();
            SavePlayerDataToJson();
            return;
        }

        FileStream fileStream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);

        mySaveData = JsonUtility.FromJson<SaveData>(jsonData);
        //돈 읽어서 불러오기
    }

    [Serializable]
    public class SaveData{
        public int int_conqueredMonster;
        public List<int> Purchased_Equipments_index;
        public List<int> equiping_Equipments_index;
        public int myMoney;

        public SaveData(int conqueredmonster = 0)
        {
            int_conqueredMonster = conqueredmonster;
            Purchased_Equipments_index = null;
            equiping_Equipments_index = null;
            myMoney = 0;
        }

        public void changeItem(ItemCategory itemCategory ,int index)
        {
            equiping_Equipments_index.RemoveAt((int)itemCategory);
            equiping_Equipments_index.Add(index);
            equiping_Equipments_index.Sort();
            UserData.instance.LoadMyItems();
            UserData.instance.SavePlayerDataToJson(); 
        }
    }

    public void LoadMyItems()
    {
        mySaveData.Purchased_Equipments_index.Sort();
        mySaveData.equiping_Equipments_index.Sort();  
        foreach (Item item in Managers.Data.AllitemList)
        {
            #region My Items in Inventory
            if(mySaveData.Purchased_Equipments_index.Contains(item.ItemIndex))
            {
                My_purchased_items.Add(item);
            }
            #endregion

            #region 현재 내 장비 저장
            if(mySaveData.equiping_Equipments_index.Contains(item.ItemIndex))
            {
                switch (item.itemCategory)
                {
                    case ItemCategory.Amplifier:
                        myEquipItems.EquipedAmplifier = item;
                        break;
                    case ItemCategory.Necklace:
                        myEquipItems.EquipedNecklace = item;
                        break;
                    case ItemCategory.Bracelet:
                        myEquipItems.EquipedBracelet = item;
                        break;
                    case ItemCategory.Earrings:
                        myEquipItems.EquipedEarrings = item;
                        break;
                    case ItemCategory.Balance:
                        myEquipItems.EquipedBalance = item;
                        break;
                    default:
                        myEquipItems.EquipedDestroy = item;
                        break;
                }
            }
            #endregion
        }  
    }
}
