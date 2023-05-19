using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.Networking;

public class MonsterParser : MonoBehaviour
{
    IEnumerator sendRequestAndSaveItem(string Url, ItemCategory _ItemCategory)
    {
        UnityWebRequest www = UnityWebRequest.Get(Url);
        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error!");
        }

        else
        {
            //Data parsing
            string data = www.downloadHandler.text;
            string[] line = data.Substring(0, data.Length - 1).Split('\n');
            for (int i = 0; i < line.Length; i++)
            {
                string[] row = line[i].Split('\t');            
                Managers.Data.AllitemList.Add(new Item(row[0], int.Parse(row[1]), int.Parse(row[2]), row[3], _ItemCategory));
            }
        }
    }

    const string AmpUrl  = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&range=A2:D";
    
    
    public void Init()
    {
        StartCoroutine(sendRequestAndSaveItem(AmpUrl,  ItemCategory.Amplifier));
    }
}
