﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamage, IDoAction
{
    public string Name => _name;
    public int HP => _hp;
    public int MP => _mp;
    public int MaxHP => _maxHp;
    public int MaxMP => _maxMp;
    public int Power => _power;
    public int DefensePower => _defensePower;
    public int Speed => _speed;
    public int EXP => _exp;
    public int Gold => _gold;
    public List<SkillData> Skill => _skillDatas;
    public bool IsAlive => _hp > 0;

    [SerializeField]
    EnemyData _enemyData;

    string _name;
    int _hp;
    int _mp;
    int _maxHp;
    int _maxMp;
    int _power;
    int _defensePower;
    int _speed;
    int _exp;
    int _gold;
    List<SkillData> _skillDatas;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        _hp = _enemyData.MaxHP;
        _mp = _enemyData.MaxMP;
        _name = _enemyData.Name;
        _maxHp = _enemyData.MaxHP;
        _maxMp = _enemyData.MaxMP;
        _power = _enemyData.Power;
        _defensePower = _enemyData.DefensePower;
        _speed = _enemyData.Speed;
        _exp = _enemyData.EXP;
        _gold = _enemyData.Gold;
        _skillDatas = _enemyData.Skill;
    }

    void Attack()
    {
        if(BattleManager.Instance.Player.TryGetComponent(out IDamage id))
        {
            id.ReceiveDamage(_power);
        }
    }

    public void ReceiveDamage(int damage)
    {
        _hp -= damage;
        Debug.Log(Name + "は" + damage + "ダメージを受けた");
    }

    public void DoAction()
    {
        Attack();
    }
}
