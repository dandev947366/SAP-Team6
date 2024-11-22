using System.Collections.Generic;
using UnityEngine;
using System.Linq; // 引入 LINQ 命名空间

public class CraftingSystem : MonoBehaviour
{
    public InventorySystem inventory; // 引用玩家的库存
    public ItemDatabase itemDatabase; // 引用物品数据库

    // 配置合成配方
    private Dictionary<List<string>, string> craftingRecipes = new Dictionary<List<string>, string>();

    private void Start()
    {
        // 初始化合成配方
        InitializeRecipes();
    }

    // 初始化配方
    private void InitializeRecipes()
    {
        // 示例配方：木材 + 石头 = 石斧
        craftingRecipes.Add(new List<string> { "wood", "stone" }, "stoneAxe");

        // 示例配方：木材 + 木材 = 木板
        craftingRecipes.Add(new List<string> { "wood", "wood" }, "woodPlank");

        // 示例配方：糖果 + 破手套 = 废品
        craftingRecipes.Add(new List<string> { "candy", "tornGlove" }, "waste");
    }

    // 执行合成
    public string Craft(List<string> materials)
    {
        // 排序材料（确保顺序不会影响合成结果）
        materials.Sort();

        // 检查配方是否存在
        foreach (var recipe in craftingRecipes)
        {
            // 创建配方副本进行排序，避免修改原始数据
            List<string> sortedRecipe = new List<string>(recipe.Key);
            sortedRecipe.Sort();

            if (sortedRecipe.SequenceEqual(materials))
            {
                string resultID = recipe.Value;
                Item resultItem = itemDatabase.GetItemByID(resultID);

                if (resultItem != null)
                {
                    // 添加结果到背包
                    inventory.AddItem(resultItem.itemID, resultItem.itemName, 1, resultItem.icon);
                    Debug.Log($"Crafting successful! Created {resultItem.itemName}");

                    // 消耗材料
                    foreach (string materialID in materials)
                    {
                        inventory.RemoveItem(materialID, 1);
                    }

                    return resultID; // 返回合成结果的物品 ID
                }
            }
        }

        // 如果没有匹配的配方，生成废品
        Debug.Log("Crafting failed! Generating waste.");
        Item wasteItem = itemDatabase.GetItemByID("waste");
        if (wasteItem != null)
        {
            inventory.AddItem(wasteItem.itemID, wasteItem.itemName, 1, wasteItem.icon);
        }

        return "waste"; // 返回废品的物品 ID
    }
}
