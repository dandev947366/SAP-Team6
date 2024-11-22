using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public string itemID; // 存储拖放的物品 ID

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag; // 获取被拖拽的物体
        if (droppedItem != null)
        {
            DragItem dragItem = droppedItem.GetComponent<DragItem>();
            if (dragItem != null)
            {
                // 在这里可以将物品放入槽位
                Debug.Log($"Item dropped into {name}");
            }
        }
    }
}
