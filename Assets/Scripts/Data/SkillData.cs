using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "SkillData", menuName = "CreateSkillData")]
public class SkillData : ScriptableObject
{
    public Type SkillType => _type;
    public string SkillName => _skillName;
    public string SkillInformation => _information;
    public int Damage => _damage;
    public bool IsWhole => _isWhole;

    [SerializeField]
    [Header("Skillの種類")]
    Type _type;

    [SerializeField]
    [Header("技の名前")]
    [TextArea]
    string _skillName;

    [SerializeField]
    [Header("技の情報")]
    [TextArea]
    string _information;

    [SerializeField]
    [Header("技のダメージ量")]
    int _damage;

    [SerializeField]
    [Header("全体攻撃かどうか判定するフラグ")]
    bool _isWhole;


    public enum Type
    {
        NomalAttack,//通常攻撃
        Magic,//魔法
        Skill,//スキル
        Item,//アイテム
        RunAway//逃げる
    }
}
