using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseChar : MonoBehaviour
{
    [SerializeField]protected int _maxHP;
    [SerializeField]protected int _nowHP;
    [SerializeField]Slider _myHP;
    [SerializeField]protected bool _isAlive = true;

    public float _attackTerm = 3f;
    [SerializeField]protected int _attackPower;
    protected bool _hasBarrier = false;
    protected int _shieldAmount = 0;


    protected virtual void Update()
    {
        _myHP.value = (float)_nowHP/_maxHP;
        if(  _nowHP<=0 && _isAlive)
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
        if(_hasBarrier || _shieldAmount > 0)
        {
            if(_hasBarrier)
            {
                _hasBarrier = false;
                return;
            }

            if(_shieldAmount > 0)
            {
                _shieldAmount -= dam;
                return;
            }
        }

        else
            _nowHP-=dam;
    }

    protected abstract void CharacterDead();

    protected abstract void Attack();
    
}
