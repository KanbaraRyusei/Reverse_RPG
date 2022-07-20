using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleMemento
{
    Action _action;
    public BattleMemento(Action action)
    {
        _action = action;
    }

    public void RestoreMemento()
    {
        _action?.Invoke();
    }
}
