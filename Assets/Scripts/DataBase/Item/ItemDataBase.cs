using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.Networking;

public class ItemDataBase : MonoBehaviour
{
    public List<Item> AllitemList = new List<Item>();
    const string AmpUrl = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&range=A2:D";
    const string NeckUrl = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&gid=1192668254&range=A2:D";

    private void Start() {
        StartCoroutine(CallItemList());
    }
    
    IEnumerator CallItemList(){
        UnityWebRequest www = UnityWebRequest.Get(AmpUrl);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        string[] line = data.Substring(0, data.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');            
            AllitemList.Add(new Item(row[0], int.Parse(row[1]), int.Parse(row[2]), row[3], ItemCategory.Amplifier));
        }

        UnityWebRequest www2 = UnityWebRequest.Get(NeckUrl);
        yield return www2.SendWebRequest();

        string data2 = www2.downloadHandler.text;
        string[] line2 = data2.Substring(0, data2.Length - 1).Split('\n');
        for (int i = 0; i < line2.Length; i++)
        {
            string[] row = line2[i].Split('\t');            
            AllitemList.Add(new Item(row[0], int.Parse(row[1]), int.Parse(row[2]), row[3], ItemCategory.Necklace));
        }
    }
}



