using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_Monster : BaseChar
{
    public static B_Monster instance;
    Define.Monster _monster;
    public Image _monImage;

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        Init();
        StartCoroutine(BaseAttack());
    }

    void Init()
    {
        _monster = Managers.Data.ThisQuestMonster;
        _maxHP = _monster.HP;
        _nowHP = _monster.HP;
        _attackPower = _monster.attackPower;
        _attackTerm = _monster.attackTerm;
        _monImage.sprite = _monster.image;
    }

    protected override void Attack()
    {
        B_Player.instance.GetDamage(_attackPower);
    }

    protected override void CharacterDead()
    {
        throw new System.NotImplementedException();
    }
}
