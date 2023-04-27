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
    public SaveData mySaveData;
    public List<Item> My_purchased_items = new List<Item>();
    public List<Item> Now_Equip_items = new List<Item>();
    
private void Awake() {
    instance = this;
    LoadPlayerDatafromJson();
}

    private void Start() {
        StoreSection.instance.SetGoldText();
    }

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
        print(fileStream.ToString());
        string jsonData = Encoding.UTF8.GetString(data);

        mySaveData = JsonUtility.FromJson<SaveData>(jsonData);
        //돈 읽어서 불러오기
    }

    [Serializable]
    public class SaveData{
        public AlkayiaSkill Data_learnedSkill;
        public int int_conqueredMonster;
        public List<int> Purchased_Equipments_index;
        public int myMoney;

        public SaveData(AlkayiaSkill data_learnedSkill = AlkayiaSkill.IceNeedle, int conqueredmonster = 0, List<int> indexList = null)
        {
            Data_learnedSkill = data_learnedSkill;
            int_conqueredMonster = conqueredmonster;
            Purchased_Equipments_index = indexList;
            myMoney = 0;
        }
    }

    public void LoadMyPurchasedItems()
    {    
        foreach (Item item in ItemDataBase.AllitemList)
        {
            if(mySaveData.Purchased_Equipments_index.Contains(item.ItemIndex))
            {
                My_purchased_items.Add(item);
            }
        }
    }
}
