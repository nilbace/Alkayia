using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipDatas : MonoBehaviour
{
    public static EquipDatas instance;
    public enum BoardSize{
        Size4_4, Size5_5, Size6_6
    };
    [SerializeField] public BoardSize boardSize;

    const int BaseHP = 50;
    public int myHP;

    const int baseATK = 10;
    public int myATK;


    
    void Awake() //싱글턴
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

    void Start()
    {
        
    }
}
