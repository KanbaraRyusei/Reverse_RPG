using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBase : MonoBehaviour, IDamage, ISelectAction, IDoAction, IHeelHP, IHeelMP
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
    public bool IsAlive => _hp > 0;
    public PlayerAction[] PlayerActions => _playerActions;
    public List<ItemData> Items => _items;

    [SerializeField]
    PlayerData _playerData;

    [SerializeField]
    PlayerAction[] _playerActions;

    List<ItemData> _items;
    SkillData _skill;

    public event Action OnAction = null;

    string _name;
    int _hp;
    int _mp;
    int _power;
    int _defensePower;
    int _speed;
    int _maxHp;
    int _maxMp;
    List<SkillData> _skillDatas;
    GameObject _target;

    private void Awake()
    {
        Init();
    }

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
        BattleViewManager.Instance.SetPanel(true);
        BattleViewManager.Instance.SetButtonToSelectAction(_playerActions);
    }

    public void ReceiveDamage(int damage)
    {
        _hp -= damage;
        Debug.Log(Name + "は" + damage + "ダメージを受けた");
    }

    public void SetSkill(SkillData skill)
    {
        _skill = skill;
    }

    public void SetTarget(GameObject go)
    {
        _target = go;
        BattleManager.Instance.SelectedAction();
    }

    public void DoAction()
    {
        if(_target.TryGetComponent(out IDamage id))
        {
            id.ReceiveDamage(_skill.Damage);
        }
    }

    public void HeelHP(int num)
    {
        if(_hp + num > _maxHp)
        {
            num = _maxHp - _hp;
        }
        _hp += num;
    }

    public void HeelMP(int num)
    {
        if(_mp + num > _maxMp)
        {
            num = _maxMp - _mp;
        }
        _mp += num;
    }

    public void UseItem(ItemData item)
    {
        item.UseItem(gameObject);
    }
}

[Serializable]
public class PlayerAction
{
    public string ActionName => _actionName;
    public ActionType Type => _actionType;

    [SerializeField]
    [Header("アクションの名前")]
    string _actionName;

    [SerializeField]
    [Header("アクションのタイプ")]
    ActionType _actionType = ActionType.NomalAttack;

    public enum ActionType
    {
        NomalAttack,//通常攻撃
        Magic,//魔法
        Skill,//スキル
        Item,//アイテム
        Escape//逃げる
    }
}
