using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;  // 物品名称
    public string itemID;    // 物品唯一标识
    public Sprite icon;      // 物品图标
    public int value;        // 物品的价值（可选）
    public string description; // 物品描述（可选）
    public int defaultQuantity = 1; // 默认数量

}
