using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.Networking;

public class ItemDataBase : MonoBehaviour
{
    public List<Item> AllitemList = new List<Item>();

    #region Url About Items
    const string AmpUrl  = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&range=A2:D";
    const string NeckUrl = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&gid=1192668254&range=A2:D";
    const string EarUrl  = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&gid=1753661311&range=A2:D";
    #endregion

    private void Start() {
        StartCoroutine(sendRequestAndSaveItem(AmpUrl,  ItemCategory.Amplifier));
        StartCoroutine(sendRequestAndSaveItem(NeckUrl, ItemCategory.Necklace));
        StartCoroutine(sendRequestAndSaveItem(EarUrl,  ItemCategory.Earrings));
    }
    
    IEnumerator sendRequestAndSaveItem(string Url, ItemCategory _ItemCategory)
    {
        UnityWebRequest www = UnityWebRequest.Get(Url);
        yield return www.SendWebRequest();

        //Data parsing
        string data = www.downloadHandler.text;
        string[] line = data.Substring(0, data.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');            
            AllitemList.Add(new Item(row[0], int.Parse(row[1]), int.Parse(row[2]), row[3], _ItemCategory));
        }
    }
}