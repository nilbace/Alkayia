using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GooSheetManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1wBdE9hxwjJ3QqGhMYn3ql7Wyn_FCoxyv1JfouYaUe2I/export?format=tsv&range=A2:B";
    void Start()
    {
        StartCoroutine(down());
    }

    void Update()
    {
        
    }

    IEnumerator down()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        print(data);
    }
}
