using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsome : MonoBehaviour
{
    [SerializeField] TextAsset temp;
    void Start()
    {
        string temp2 = temp.text;
        string[] line = temp2.Substring(0, temp2.Length - 1).Split('\n');
            for (int i = 0; i < line.Length; i++)
            {
                string[] row = line[i].Split('\t');            
                for(int j = 0; j<row.Length; j++)
                {
                    print(row[j]);
                    if((row[j]) == "TRUE")
                    {
                        print("trueisTrue");
                    }
                }
            }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
