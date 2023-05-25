using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChar : MonoBehaviour
{
    protected int _maxHP;
    protected int _nowHP;

    public float _attackTerm = 3f;
    protected int _attackPower;


    protected virtual void Update()
    {
        if(_nowHP<=0)
            CharacterDead();
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

    }

    protected void Attack()
    {

    }
}
