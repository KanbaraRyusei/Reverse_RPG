using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ShopManager : SingletonMonoBehaviour<ShopManager>
{
    [SerializeField]
    [Header("購入,売却")]
    GameObject Sold_Panel;
    [SerializeField]
    [Header("アイテム一覧")]
    GameObject Item_Panel;
    
  
    


    private void Start()
    {
        Sold_Panel.SetActive(false);
        Item_Panel.SetActive(false);
    }
    public void Shop()
    {
        Sold_Panel.SetActive(true);
    
    }
}