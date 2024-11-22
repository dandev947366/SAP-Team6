using UnityEngine;
using UnityEngine.UI;

public class MaterialSlot : MonoBehaviour
{
    public string itemID; // 存储槽内的物品 ID
    public Image iconImage; // 显示物品图标的 UI

    // 设置槽内的物品
    public void SetItem(string id, Sprite icon)
    {
        itemID = id;

        if (iconImage != null)
        {
            iconImage.sprite = icon;
            iconImage.color = Color.white; // 确保图标可见
        }
    }

    // 清空槽位
    public void ClearSlot()
    {
        itemID = null;

        if (iconImage != null)
        {
            iconImage.sprite = null;
            iconImage.color = new Color(1, 1, 1, 0); // 设置图标为透明
        }
    }
}
