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
    string playerData;
    
private void Awake() {
    instance = this;
    LoadPlayerDatafromJson();
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
    }

    [Serializable]
    public class SaveData{
        //기본 생성자
     

        public AlkayiaSkill Data_learnedSkill;
        public int int_conqueredMonster;

        public SaveData(AlkayiaSkill data_learnedSkill = AlkayiaSkill.IceNeedle, int conqueredmonster = 0)
        {
            Data_learnedSkill = data_learnedSkill;
            int_conqueredMonster = conqueredmonster;
        }
    }
}
