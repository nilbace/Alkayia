using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.Networking;
using System;

public class DataManager
{
    public List<Define.Item> AllitemList = new List<Define.Item>();
    public Dictionary<string, Monster> AllMonsterList = new Dictionary<string, Monster>();
}
