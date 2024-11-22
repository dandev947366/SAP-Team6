using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ItemData itemData; // 绑定 ScriptableObject 数据

    private void Start()
    {
        // 动态设置 Sprite Renderer 的图像
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (itemData != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = itemData.icon; // 使用 ItemData 中的图标
        }
    }

public void Collect()
{
    InventorySystem inventory = FindObjectOfType<InventorySystem>();
    if (inventory != null && itemData != null)
    {
        inventory.AddItem(itemData.itemID, itemData.itemName, itemData.defaultQuantity, itemData.icon); // 使用默认数量
        Debug.Log($"Collected: {itemData.itemName}");
    }

    Destroy(gameObject); // 收集后销毁物品
}


}
