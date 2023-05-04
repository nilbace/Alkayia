using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;
public class SkillTree : MonoBehaviour
{
    [SerializeField]SkillVersionData ThisSkillData;
    [SerializeField]Image MainIcon;
    [SerializeField]Image FirstProperty;
    [SerializeField]Image SecondProperty;
    [SerializeField]ScrollRect SkillTreeScroll;

    private void Start() {
        SkillTreeScroll = GameObject.Find("SkillScrollView").GetComponent<ScrollRect>();
    }
    public void setSkillTree(SkillVersionData skillData)
    {
        ThisSkillData = skillData;
    }

    public void ClickFirstProperty()
    {
        print("Frist" + ThisSkillData.skillName);
    }

    public void ChickSecondProperty()
    {
        print("SEcond" + ThisSkillData.skillName);
    }
}
