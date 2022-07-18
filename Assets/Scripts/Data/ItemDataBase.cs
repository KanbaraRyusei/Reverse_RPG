using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemDataBase",menuName ="CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    List<ItemData> Items = new List<ItemData>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<ItemData> GetItems()
    {
        return Items;
    }
}
