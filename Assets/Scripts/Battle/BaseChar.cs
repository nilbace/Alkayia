using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChar : MonoBehaviour
{
    [SerializeField]protected int _maxHP;
    [SerializeField]protected int _nowHP = 98574;
    [SerializeField]protected bool _isAlive = true;

    public float _attackTerm = 3f;
    [SerializeField]protected int _attackPower;


    protected virtual void Update()
    {
        if( _nowHP != 98574 && _nowHP<=0 && _isAlive)
        {
            _isAlive = false;
            CharacterDead();
        }
    }

    protected IEnumerator BaseAttack()
    {
        while(true)
        {
            yield return new WaitForSeconds(_attackTerm);
            Attack();
        }
    }

    public void GetDamage(int dam)
    {
        _nowHP-=dam;

    }

    protected virtual void CharacterDead()
    {
        print("캐릭터 사망");
    }

    protected virtual void Attack()
    {
        print("공격!");
    }
}
