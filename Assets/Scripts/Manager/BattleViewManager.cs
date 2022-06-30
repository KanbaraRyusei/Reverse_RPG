using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BattleViewManager : SingletonMonoBehaviour<BattleViewManager>
{
    [SerializeField]
    [Header("表示するパネル")]
    GameObject _panel;

    [SerializeField]
    [Header("表示するボタン")]
    Button _button;

    List<Button> _buttons = new List<Button>();

    public void SetPanel(bool flag)
    {
        _panel.SetActive(flag);
    }

    public void SetButtonToSelectAction(IReadOnlyList<PlayerAction> playerActions)
    {
        ButtonSetting(playerActions.Count);
        for (int i = 0; i < ButtonSearch(); i++)
        {
            var x = i;
            ButtonTextChenge(_buttons[x], playerActions[x].ActionName);
            _buttons[x].onClick.AddListener(() =>
            DirectionSetButton(playerActions[x].Type)
            );
        }
    }

    void ButtonSetting(int needButtonNum)
    {
        ResetListenerMethod();
        if(_buttons.Count < needButtonNum)
        {
            ButtonGenerate(needButtonNum - _buttons.Count);
        }
        HideButton();
        NotHideButton(needButtonNum);
        _buttons[0].Select();
    }

    void SetButtonToTargetDecision()
    {
        ButtonSetting(BattleManager.Instance.Enemies.Length);
        for (int i = 0; i < BattleManager.Instance.Enemies.Length; i++)
        {
            var x = i;
            ButtonTextChenge(_buttons[x], BattleManager.Instance.Enemies[x].GetComponent<EnemyBase>().Name);
            _buttons[x].onClick.AddListener(() => BattleManager.Instance.Player.SetTarget(BattleManager.Instance.Enemies[x]));
        }
    }

    int ButtonSearch()
    {
        return _buttons.Where(x => x.gameObject.activeSelf).Count();
    }

    void ButtonTextChenge(Button button, string str)
    {
        button.GetComponentInChildren<Text>().text = str;
    }

    void ButtonGenerate(int num)// Buttonが足りなくなったら生成する
    {
        for (int i = 0; i < num; i++)
        {
            var button = Instantiate(_button, _panel.transform);
            button.transform.position = _panel.transform.position;
            _buttons.Add(button);
        }
    }

    void NotHideButton(int num)
    {
        for (int i = 0; i < num; i++)
        {
            _buttons[i].gameObject.SetActive(true);
        }
    }

    void HideButton()// Buttonを隠す
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].gameObject.SetActive(false);
        }
    }

    void ResetListenerMethod()// Buttonに登録されている関数を全て削除する
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].onClick.RemoveAllListeners();
        }
    }

    void DirectionSetButton(PlayerAction.ActionType actionType)
    {
        switch (actionType)
        {
            case PlayerAction.ActionType.NomalAttack:
                SetButtonToSelectAction(BattleManager.Instance.Player.Skill.Where(x => x.SkillType == SkillData.Type.NomalAttack).ToList());
                break;
            case PlayerAction.ActionType.Magic:
                SetButtonToSelectAction(BattleManager.Instance.Player.Skill.Where(x => x.SkillType == SkillData.Type.Magic).ToList());
                break;
            case PlayerAction.ActionType.Skill:
                SetButtonToSelectAction(BattleManager.Instance.Player.Skill.Where(x => x.SkillType == SkillData.Type.Skill).ToList());
                break;
            case PlayerAction.ActionType.Item:
                SetButtonToSelectItem(BattleManager.Instance.Player.Items);
                break;
            case PlayerAction.ActionType.Escape:
                BattleManager.Instance.Escape();
                break;
        }
    }

    void SetButtonToSelectAction(IReadOnlyList<SkillData> skills)
    {
        ButtonSetting(skills.Count);
        for (int i = 0; i < ButtonSearch(); i++)
        {
            var x = i;
            ButtonTextChenge(_buttons[x], skills[x].SkillName);
            _buttons[x].onClick.AddListener(() =>
            {
                BattleManager.Instance.Player.SetSkill(skills[x]);
                SetButtonToTargetDecision();
            });
        }
    }

    void SetButtonToSelectItem(IReadOnlyList<ItemData> items)
    {
        ButtonSetting(items.Count);
        for (int i = 0; i < ButtonSearch(); i++)
        {
            var x = i;
            ButtonTextChenge(_buttons[x], items[x].Name);
            _buttons[x].onClick.AddListener(() =>
            {
                BattleManager.Instance.Player.UseItem(items[x]);
            });
        }
    }
}
