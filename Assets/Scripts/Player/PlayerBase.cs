using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamage, ISelectAction
{
    public string Name => _name;
    public int HP => _hp;
    public int MP => _mp;
    public int MaxHP => _maxHp;
    public int MaxMP => _maxMp;
    public int Power => _power;
    public int DefensePower => _defensePower;
    public int Speed => _speed;
    public List<SkillData> Skill => _skillDatas;

    [SerializeField]
    PlayerData _playerData;

    string _name;
    int _hp;
    int _mp;
    int _power;
    int _defensePower;
    int _speed;
    int _maxHp;
    int _maxMp;
    List<SkillData> _skillDatas;

    void Init()
    {
        _hp = _playerData.MaxHP;
        _mp = _playerData.MaxMP;
        _name = _playerData.Name;
        _power = _playerData.Power;
        _defensePower = _playerData.DefensePower;
        _speed = _playerData.Speed;
        _maxHp = _playerData.MaxHP;
        _maxMp = _playerData.MaxMP;
        _skillDatas = _playerData.Skill;
    }

    public void SelectAction()
    {
        //BattleViewManager.Instance.SetPanel(true);

    }

    public void ReceiveDamage(int damage)
    {
        _hp -= damage;
    }
}
