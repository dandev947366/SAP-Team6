using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 引入 TextMeshPro 的命名空间

public class InventoryUI : MonoBehaviour
{
    public InventorySystem inventorySystem; // 引用库存系统
    public Transform contentPanel; // Grid Layout 的 Content 对象
    public GameObject itemTemplate; // InventoryItemTemplate 预制件

    // 更新 UI
    public void RefreshInventoryUI()
    {
        // 清空当前 UI
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        Debug.Log($"Refreshing Inventory UI. Total items: {inventorySystem.items.Count}");

        // 固定格子数
        int maxSlots = 49;
        int displayedItems = Mathf.Min(inventorySystem.items.Count, maxSlots);

        // 遍历库存中的物品
        for (int i = 0; i < displayedItems; i++)
        {
            Item item = inventorySystem.items[i];
            Debug.Log($"Adding item to UI: {item.itemName}, Quantity: {item.quantity}");

            GameObject newItem = Instantiate(itemTemplate, contentPanel);
            newItem.SetActive(true);

            // 设置 CanvasGroup
            CanvasGroup canvasGroup = newItem.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = newItem.AddComponent<CanvasGroup>(); // 如果没有，添加 CanvasGroup 组件
            }
            // 确保 CanvasGroup 被启用
            canvasGroup.enabled = true;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true; // 确保启用
            canvasGroup.alpha = 1f;

            // 设置物品图标
            Image itemIcon = newItem.GetComponent<Image>();
            if (itemIcon != null)
            {
                itemIcon.sprite = item.icon;
                itemIcon.enabled = true;
            }

            // 设置物品数量
            TextMeshProUGUI quantityText = newItem.transform.Find("QuantityText").GetComponent<TextMeshProUGUI>();
            if (quantityText != null)
            {
                quantityText.enabled = true; // 确保启用
                quantityText.text = item.quantity > 1 ? $"{item.quantity}" : "";
            }
            else
            {
                Debug.LogWarning("QuantityText (TextMeshProUGUI) not found or not set.");
            }
        }

        // 填充剩余空格
        for (int i = displayedItems; i < maxSlots; i++)
        {
            GameObject emptySlot = Instantiate(itemTemplate, contentPanel);
            emptySlot.SetActive(true);

            // 设置 CanvasGroup
            CanvasGroup canvasGroup = emptySlot.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = emptySlot.AddComponent<CanvasGroup>(); // 如果没有，添加 CanvasGroup 组件
            }
            canvasGroup.enabled = true;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true; // 确保启用
            canvasGroup.alpha = 1f;

            // 清空图标
            Image emptyIcon = emptySlot.GetComponent<Image>();
            if (emptyIcon != null)
            {
                emptyIcon.sprite = null;
                emptyIcon.enabled = false;
            }

            // 清空数量文字
            TextMeshProUGUI emptyQuantityText = emptySlot.transform.Find("QuantityText").GetComponent<TextMeshProUGUI>();
            if (emptyQuantityText != null)
            {
                emptyQuantityText.enabled = false; // 禁用空格子的文本
                emptyQuantityText.text = "";
            }
        }
    }


    private void Start()
    {
        RefreshInventoryUI(); // 初始化 UI
    }
}
