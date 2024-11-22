using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // 玩家库存
    public ItemDatabase itemDatabase; // 物品数据库引用（可选）

    // 检查是否有足够的某种物品
    public bool HasItem(string itemID, int quantity)
    {
        Item item = items.Find(i => i.itemID == itemID);
        return item != null && item.quantity >= quantity;
    }

    // 增加物品到库存
public void AddItem(string itemID, string itemName, int quantity, Sprite icon)
{
    Item existingItem = items.Find(i => i.itemID == itemID);

    if (existingItem != null)
    {
        existingItem.quantity += quantity;
    }
    else
    {
        items.Add(new Item
        {
            itemID = itemID,
            itemName = itemName,
            quantity = quantity,
            icon = icon
        });
    }
}


    // 移除物品
    public void RemoveItem(string itemID, int quantity)
    {
        Item item = items.Find(i => i.itemID == itemID);

        if (item != null)
        {
            item.quantity -= quantity;
            if (item.quantity <= 0)
            {
                items.Remove(item); // 数量小于等于 0 时移除物品
            }
        }
        else
        {
            Debug.LogWarning($"Item with ID '{itemID}' not found in inventory.");
        }
    }

    // 从数据库获取物品信息
    private Item GetItemFromDatabase(string itemID)
    {
        if (itemDatabase == null)
        {
            Debug.LogError("ItemDatabase is not assigned!");
            return null;
        }

        return itemDatabase.GetItemByID(itemID);
    }
}
