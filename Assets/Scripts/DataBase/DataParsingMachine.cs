using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataParsingMachine : MonoBehaviour
{
    public static DataParsingMachine Inst;
    public TextAsset MonsterDatas;
    public List<Monster> AllMonList;
    private void Awake() {
        Inst = this;
    }

    void Start()
    {
        string[] line = MonsterDatas.text.Substring(0, MonsterDatas.text.Length - 1).Split('\n');
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');            
            AllMonList.Add(new Monster(row[0], int.Parse(row[1]), int.Parse(row[2]), 
            int.Parse(row[3]), row[4]));
        }
    }

    void Update()
    {
        
    }


}
[System.Serializable]
public class Monster{
    public string name;
    public int attackPower;
    public int attackTerm;
    public int HP;
    public string boardExplanation;

    public Monster(string name = "몬스떠!", 
    int attackPower = 5, 
    int attackTerm = 5, 
    int hP = 30
    , string boardExplanation = "이게 보이면 안된다!")
    {
        this.name = name;
        this.attackPower = attackPower;
        this.attackTerm = attackTerm;
        HP = hP;
        this.boardExplanation = boardExplanation;
    }
}