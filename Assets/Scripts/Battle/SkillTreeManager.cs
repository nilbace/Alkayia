using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class SkillTreeManager : MonoBehaviour{

    [SerializeField] Transform SkillTreeContent;
    [SerializeField] GameObject SkillTree;

    [SerializeField] SkillVersionData[] mySkillVersionDatas = new SkillVersionData[10];

    private void Start() {
        for(int i = 0; i < 10; i++)
        {
            GameObject tempTree = MonoBehaviour.Instantiate(SkillTree, SkillTreeContent);
            tempTree.GetComponent<SkillTree>().setSkillTree(mySkillVersionDatas[i]);
        }
        gameObject.SetActive(false);
    }

    public void StartHunt()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
    }
}
