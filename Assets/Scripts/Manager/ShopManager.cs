using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Linq;

public class ShopManager : SingletonMonoBehaviour<ShopManager>
{


    [SerializeField]
    [Header("表示するパネル")]
    GameObject _panel;
    [SerializeField]
    [Header("アイテムを表示するパネル")]
    GameObject _Item_panel;

    [SerializeField]
    [Header("表示するボタン")]
    Button _button;

    List<Button> _buttons = new List<Button>();

    [SerializeField]
    [Header("表示したいアイテムデータ")]
    List<ItemData> Items = new List<ItemData>();

    int ItemNumbar;

    [SerializeField]
    [Header("表示したいButtonの数")]
    int ButtonNumbers;







    private void Start()
    {
        _panel.SetActive(false);
        _Item_panel.SetActive(false);
        //_panel.SetActive(false);
    }
    public void ShopOpen()
    {
        _panel.SetActive(true);
        ButtonSetting(ButtonNumbers + ItemNumbar);

        for (int i = 0; i < ButtonSearch(); i++)
        {
            var x = i;
            _buttons[x].onClick.AddListener(() => _Item_panel.SetActive(true));
            ItemGenerate();
        }
    }
    void ButtonSetting(int needButtonNum)
        {
            ResetListenerMethod();
            if (_buttons.Count < needButtonNum)
            {
                ButtonGenerate(needButtonNum - _buttons.Count);
            }
            HideButton();
            NotHideButton(needButtonNum);
            _buttons[0].Select();
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
        void ItemGenerate()
        {
           
            foreach(var i in Items)
            {
                ItemNumbar++;
                var button = Instantiate(_button, _Item_panel.transform);
                button.transform.position = _Item_panel.transform.position;
                _buttons.Add(button);

            }

          


        }
        int ButtonSearch()
        {
            return _buttons.Where(x => x.gameObject.activeSelf).Count();
        }
        void Event(int num)
        {
            Debug.Log(num + "が押された");
        }
        void ButtonTextChenge(Button button, string str)
        {
            button.GetComponentInChildren<Text>().text = str;
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


    }


  
