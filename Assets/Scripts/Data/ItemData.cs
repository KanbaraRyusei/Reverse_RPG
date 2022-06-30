using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "ItemData", menuName = "CreateItemData")]
public class ItemData : ScriptableObject
{
    public Param Parameter => _param;
    public int Heel => _heel;
    public string Name => _name;
    public string Explanation => _explanation;
    public Sprite ItemSprite => _sprite;

    [SerializeField]
    [Header("回復するパラメータ")]
    Param _param = Param.HP;

    [SerializeField]
    [Header("回復量")]
    int _heel;

    [SerializeField]
    [Header("アイテム名")]
    string _name;

    [SerializeField]
    [Header("説明")]
    string _explanation;

    [SerializeField]
    [Header("画像")]
    Sprite _sprite;

    public enum Param
    {
        HP,
        MP
    }

    public void UseItem(GameObject go)
    {
        if(_param == Param.HP)
        {
            if (go.TryGetComponent(out IHeelHP ih))
            {
                ih.HeelHP(_heel);
            }
        }
        else
        {
            if(go.TryGetComponent(out IHeelMP ih))
            {
                ih.HeelMP(_heel);
            }
        }
    }
}
