using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.Networking;
public class ItemParser : MonoBehaviour
{
    int isdone = 0;
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
            isdone++;
            if(isdone==7)
            {
                UserData.instance.LoadMyItems();
                Managers.UI.ShowSceneUI<UI_Login>();
            }
        }
    }

    const string AmpUrl  = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&range=A2:D";
    const string NeckUrl = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&gid=1192668254&range=A2:D";
    const string BraceUrl  = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&gid=917788105&range=A2:D";
    const string EarUrl  = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&gid=1753661311&range=A2:D";
    const string DesUrl  = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&gid=783504121&range=A2:D";
    const string BalUrl  = "https://docs.google.com/spreadsheets/d/1M_lVqFwKkgKOZP22-Srb2nFUN3hk-RkFeA-Uox2bb1A/export?format=tsv&gid=470343613&range=A2:D";

    #region MonsterParsing
    IEnumerator sendRequestAndSaveMon(string Url)
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
                Managers.Data.AllMonsterList.Add(new Monster(row[0], int.Parse(row[1]), float.Parse(row[2]), int.Parse(row[3]),  row[4], i, row[5] ));
            }

            isdone++;
            if(isdone==7)
            {
                UserData.instance.LoadMyItems();
                Managers.UI.ShowSceneUI<UI_Login>();
            }
        }
    }

    const string MonstersURL  = "https://docs.google.com/spreadsheets/d/1vtg02MKZum53xIGW9G9MQ2L238bLSO-kVIpJJhbR22Y/export?format=tsv&range=A2:FD";
    
    #endregion
    
    
    public void Init()
    {
        StartCoroutine(sendRequestAndSaveItem(AmpUrl,  ItemCategory.Amplifier));
        StartCoroutine(sendRequestAndSaveItem(NeckUrl, ItemCategory.Necklace));
        StartCoroutine(sendRequestAndSaveItem(BraceUrl,ItemCategory.Bracelet));
        StartCoroutine(sendRequestAndSaveItem(EarUrl,  ItemCategory.Earrings));
        StartCoroutine(sendRequestAndSaveItem(DesUrl,  ItemCategory.Destroy));
        StartCoroutine(sendRequestAndSaveItem(BalUrl,  ItemCategory.Balance));
        StartCoroutine(sendRequestAndSaveMon(MonstersURL));
    }

    private void Start() {
        Init();
        DontDestroyOnLoad(gameObject);
    }
}
