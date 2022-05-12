﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "MagicData", menuName = "CreateMagicData")]
public class MagicData : SkillData
{
    public int NeedMP => _needMp;
    public Attribute MagicAttribute => _attribute;

    [SerializeField]
    [Header("必要なMP")]
    int _needMp;

    [SerializeField]
    [Header("属性")]
    Attribute _attribute;

    public enum Attribute
    {
        Fire,//火属性
        Water,//水属性
        Lightning//雷属性
    }
}
