using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Define;
using UnityEngine.SceneManagement;

public class MonsterInfo : MonoBehaviour
{
    static MonsterInfo Inst;
    public TMP_Text MonsterName;
    public TMP_Text MonsterInfos;
    private void Awake() {
        Inst = this;
    }

    private void Start() {
        gameObject.SetActive(false);
    }
    public static void OpenInfoPopup(Monster monster)
    {
        Inst.setting(monster);
    }

    void setting(Monster monster){
        this.MonsterName.text = monster.name;
        this.MonsterInfos.text = monster.boardExplanation;
        gameObject.SetActive(true);
    }

    public void CloseBTN()
    {
        gameObject.SetActive(false);
    }
    
    public void StartHunt()
    {
        SceneManager.LoadScene(2);
    }
}
