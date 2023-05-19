using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System;
using System.IO;
using System.Collections;
using static Define;

public class ParsingMachine : MonoBehaviour
{
    
    public List<Sprite> CharImage = new List<Sprite>();

    public static ParsingMachine instance;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start() {
        LoadBase();
    }

    public static List<DialogueData> DiaList = new List<DialogueData>();
    public static List<DialogueData> MyItem = new List<DialogueData>();

    void ParsingJsonDialogue(JsonData name, List<DialogueData> listDia)
    {
        for(int i = 0; i<name.Count; i++)
        {
            string tempindex =          name[i][0].ToString();
            string tempspeech =         name[i][1].ToString();
            string tempname =           name[i][2].ToString();
            string tempisleft =         name[i][3].ToString();
            string tempiscenter =       name[i][4].ToString();
            string tempfeeling =        name[i][5].ToString();
            string tempExtraEvent =     name[i][6].ToString();

            int _tempindex =      int.Parse(tempindex);
            bool _tempisleft =    bool.Parse(tempisleft);
            bool _tempisCenter =  bool.Parse(tempiscenter);

            DialogueData tempdia = new DialogueData(_tempindex, tempspeech, tempname, _tempisleft, _tempisCenter, tempfeeling, tempExtraEvent);
            switch(tempdia.name)
            {
                case "Alkayia":
                tempdia.Portrait = CharImage[(int)CharName.Alkayia];
                break;

                case "Nadira":
                tempdia.Portrait = CharImage[(int)CharName.Nadira];
                break;

                case "Lyra":
                tempdia.Portrait = CharImage[(int)CharName.Lyra];
                break;

                case "Siro":
                tempdia.Portrait = CharImage[(int)CharName.Siro];
                break;
            }
            listDia.Add(tempdia);
        }
    }

    JsonData DiaData;
    void LoadBase()
    {
        string Jsonstring;
        string filePath;

        filePath = Application.streamingAssetsPath + "/Diatest.json";
        if(Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while(!reader.isDone){}
            Jsonstring = reader.text;
        }
        else
        {
            Jsonstring = File.ReadAllText(filePath);
        }
        DiaData = JsonMapper.ToObject(Jsonstring);
        ParsingJsonDialogue(DiaData, DiaList);
    }
    
}

[Serializable]
public class DialogueData
{
    public int index;
    public string speech;
    public string name;
    public bool isLeft;
    public bool isCenter;
    public string feeling;
    public string ExtraEvent;


    public Sprite Portrait = null;


    public DialogueData(int _index, string _speech, string _name, bool _isLeft, bool _isCenter, string _feeling, string _ExtraEvent)
    {
        this.index = _index;
        this.speech = _speech;
        this.name = _name;
        this.isLeft = _isLeft;
        this.isCenter = _isCenter;
        this.feeling = _feeling;
        this.ExtraEvent = _ExtraEvent;
    }
}