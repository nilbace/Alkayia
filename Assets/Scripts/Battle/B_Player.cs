using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.UI;

public class B_Player : BaseChar
{
    public static B_Player instance;
    LydiaStat _lydiaStat;
    
    Button[] _mySkillBTNs;

    
    private void Awake() {
        instance = this;
    }

    void Start()
    {
        Init();
        StartCoroutine(BaseAttack());
    }

    override protected void Update() {
        base.Update();
    }

    

    void Init()
    {
        _lydiaStat = Managers.Data.LydiaStat;
        //Scene에서 Awake에 초기화 완료된 값

        _nowHP = _lydiaStat.HP;
        _maxHP = _lydiaStat.HP;

        _attackPower = _lydiaStat.AttackPower;
    }

    
    protected override void Attack()
    {
        B_Monster.instance.GetDamage(_attackPower);
    }
    
    protected override void CharacterDead()
    {
        print("리디아 사망");
    }

    protected void ShowMySkills()
    {
        
    }
}
