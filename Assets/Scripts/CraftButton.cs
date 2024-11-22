using UnityEngine;
using UnityEngine.UI; // 确保导入 UI 模块
using System.Collections.Generic;

public class CraftButton : MonoBehaviour
{
    public MaterialSlot slot1; // 合成槽 1
    public MaterialSlot slot2; // 合成槽 2
    public InventorySystem inventorySystem; // 玩家背包
    public Image resultSlot; // 显示合成结果的 UI
    public CraftingSystem craftingSystem; // 合成逻辑系统

    public void OnCraftButtonClick()
    {
        Debug.Log($"Slot1 ItemID: {slot1.itemID}, Slot2 ItemID: {slot2.itemID}");
        Debug.Log("Craft button clicked");
        if (string.IsNullOrEmpty(slot1.itemID) || string.IsNullOrEmpty(slot2.itemID))
        {
            Debug.LogWarning("Not enough materials for crafting!");
            return;
        }

        // 调用合成逻辑并获取结果 ID
        string resultID = craftingSystem.Craft(new List<string> { slot1.itemID, slot2.itemID });

        if (!string.IsNullOrEmpty(resultID))
        {
            Item resultItem = inventorySystem.itemDatabase.GetItemByID(resultID);
            if (resultItem != null)
            {
                // 显示合成结果
                resultSlot.sprite = resultItem.icon;
                resultSlot.color = Color.white;

                // 从背包中移除材料
                inventorySystem.RemoveItem(slot1.itemID, 1);
                inventorySystem.RemoveItem(slot2.itemID, 1);

                Debug.Log($"Crafting successful! Created {resultItem.itemName}");
            }
        }
        else
        {
            Debug.LogWarning("Crafting failed: No matching recipe!");
        }
    }

}
