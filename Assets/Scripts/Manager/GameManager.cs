using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    [Header("コイン")]
    int Coni;

    [SerializeField]
    [Header("経験値")]
    int Exp;

    
}
