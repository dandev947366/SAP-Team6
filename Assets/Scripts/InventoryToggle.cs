using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUI; // 指向背包 UI 的根对象

    private bool isInventoryOpen = false; // 背包的显示状态

    void Update()
    {
        // 检测按键输入
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    // 切换背包显示状态
    private void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen; // 切换状态
        inventoryUI.SetActive(isInventoryOpen); // 根据状态显示或隐藏 UI
    }
}
