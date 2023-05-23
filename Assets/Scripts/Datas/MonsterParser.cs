using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.Networking;

public class MonsterParser : MonoBehaviour
{
    IEnumerator sendRequestAndSaveItem(string Url)
    {
        UnityWebRequest www = UnityWebRequest.Get(Url);
        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error!");
        }

        else
        {
            Managers.Data.AllMonsterList.Clear();
            //Data parsing
            string data = www.downloadHandler.text;
            string[] line = data.Substring(0, data.Length - 1).Split('\n');
            for (int i = 0; i < line.Length; i++)
            {
                string[] row = line[i].Split('\t');            
                Managers.Data.AllMonsterList.Add(row[0] ,new Monster(row[0], int.Parse(row[1]), int.Parse(row[2]), int.Parse(row[3]),  row[4], i, row[5] ));
            }
        }
    }

    const string MonstersURL  = "https://docs.google.com/spreadsheets/d/1vtg02MKZum53xIGW9G9MQ2L238bLSO-kVIpJJhbR22Y/export?format=tsv&range=A2:FD";
    
    
    public void Init()
    {
        StartCoroutine(sendRequestAndSaveItem(MonstersURL));
    }

    private void Start() {
        Init();
    }
}
