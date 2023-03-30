using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class UserData : MonoBehaviour
{
    public enum AlkayiaSkill{
        IceNeedle, 
        IceShield, 
        IceSpear, 
        IceThorn, 
        IceShower, 
        IceStorm, 
        IceSword, 
        IceHammer, 
        IceBreath,
        MaxCount
    }
    [SerializeField] AlkayiaSkill LearnedSkill;
    public enum MonsterList{
        None,
        Smile, 
        Goblin, 
        Ent, 
        Fairy, 
        Wolf, 
        Orc, 
        Demon,
        MaxCount
    }

    [SerializeField] MonsterList ConqueredMonster;
    SaveData mySaveData;
    string playerData;
    void Start()
    {
        Init();
    }

    void Init()
    {

    }

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
            //mySaveData = new SaveData();
            return;
        }

        FileStream fileStream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        print(fileStream.ToString());
        string jsonData = Encoding.UTF8.GetString(data);

        //playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }
    

    [Serializable]
    public class SaveData{
        SaveData()
        {
            Data_learnedSkill = AlkayiaSkill.IceNeedle;
            Data_conquered = MonsterList.None;
        }
        AlkayiaSkill Data_learnedSkill;
        MonsterList  Data_conquered;
        
    }
}
