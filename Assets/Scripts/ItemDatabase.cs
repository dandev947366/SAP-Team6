using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> items = new List<Item>(); // 所有物品列表

    public Item GetItemByID(string id)
    {
        return items.Find(item => item.itemID == id);
    }
}
