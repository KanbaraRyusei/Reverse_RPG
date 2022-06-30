using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    public PlayerBase Player => _player;
    public GameObject[] Enemies => _enemies;

    [SerializeField]
    [Header("Playerのタグ")]
    string _playerTag = "Player";

    [SerializeField]
    [Header("Enemyのタグ")]
    string _enemyTag = "Enemy";

    [SerializeField]
    [Header("マップシーンの名前")]
    string _mapSceneName;

    PlayerBase _player;
    GameObject[] _enemies;

    public event Action OnBattleEnd;

    private void Start()
    {
        BattleStart();
    }

    async void BattleStart()
    {
        await Task.Delay(1000);
        _enemies = GetFighters(_enemyTag).Where(x => x.GetComponent<EnemyBase>().IsAlive).ToArray();
        if(GetFighter(_playerTag).TryGetComponent(out PlayerBase playerBase))
        {
            _player = playerBase;
            if(playerBase.TryGetComponent(out ISelectAction ia))
            {
                ia.SelectAction();
            }
        }
    }

    void ActionStart()
    {
        CompareSpeed(_player, GetFighters(_enemyTag)).ForEach(x =>
        {
            if(x.TryGetComponent(out EnemyBase enemy) && !enemy.IsAlive)
            {
                return;
            }
            if (x.TryGetComponent(out IDoAction id))
            {
                id.DoAction();
            }
        });
        TurnEnd();
    }

    void TurnEnd()
    {
        if(!Player.IsAlive)
        {
            Debug.Log("PlayerDead");
            BattleEnd();
        }
        else if(Enemies.Where(x => x.GetComponent<EnemyBase>().IsAlive).ToArray().Length <= 0)
        {
            Debug.Log("EnemiesDaed");
            BattleEnd();
        }
        else
        {
            OnBattleEnd?.Invoke();
            OnBattleEnd = null;
            BattleStart();
        }
    }

    void BattleEnd()
    {
        Debug.Log("end");
        BattleViewManager.Instance.SetPanel(false);
        SceneLoder.LoadScene(_mapSceneName);
    }

    List<GameObject> CompareSpeed(PlayerBase player, IEnumerable<GameObject> enemies)
    {
        Dictionary<GameObject, int> gos = new Dictionary<GameObject, int>();
        gos.Add(player.gameObject, player.Speed);
        foreach (var enemy in enemies)
        {
            if(enemy.TryGetComponent(out EnemyBase e))
            {
                gos.Add(enemy, e.Speed);
            }
        }
        gos.OrderByDescending(x => x.Value);
        return gos.Keys.ToList();
    }

    GameObject GetFighter(string tag)
    {
        return GameObject.FindGameObjectWithTag(tag);
    }

    GameObject[] GetFighters(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    public void SelectedAction()
    {
        BattleViewManager.Instance.SetPanel(false);
        ActionStart();
    }

    public void Escape()
    {
        BattleEnd();
    }
}
