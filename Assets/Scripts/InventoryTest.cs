using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    private InventorySystem inventory;
    private InventoryUI inventoryUI;

    public ItemDatabase itemDatabase; // 引用物品数据库

    private void Start()
{
    if (itemDatabase == null || itemDatabase.items.Count == 0)
    {
        Debug.LogError("ItemDatabase is not set or empty!");
        return;
    }

    inventory = FindObjectOfType<InventorySystem>();
    inventoryUI = FindObjectOfType<InventoryUI>();

    // 随机生成物品
    for (int i = 0; i < 49; i++)
    {
        Item randomItem = itemDatabase.items[Random.Range(0, itemDatabase.items.Count)];
        int randomQuantity = Random.Range(1, 10); // 随机数量
        inventory.AddItem(randomItem.itemID, randomItem.itemName, randomQuantity, randomItem.icon);
    }

    // 刷新 UI
    inventoryUI.RefreshInventoryUI();
}


}
