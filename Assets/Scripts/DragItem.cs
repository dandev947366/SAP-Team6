using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler

{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // 获取或添加 CanvasGroup
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogWarning($"CanvasGroup not found on {gameObject.name}, adding dynamically.");
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.enabled = true;
        // 初始化属性
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        // 获取父级 Canvas
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas not found in parent hierarchy!", gameObject);
        }

        Debug.Log($"CanvasGroup initialized for {gameObject.name}, Blocks Raycasts: {canvasGroup.blocksRaycasts}");
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Item {gameObject.name} clicked at position {eventData.position}");
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"OnBeginDrag triggered for {gameObject.name}, starting drag.");

        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false; // 禁用检测，允许拖拽
            Debug.Log($"CanvasGroup blocksRaycasts disabled for {gameObject.name}");
        }
        else
        {
            Debug.LogError($"CanvasGroup is null on {gameObject.name} during OnBeginDrag!", gameObject);
        }

        if (canvas != null)
        {
            transform.SetParent(canvas.transform); // 设置为最上层
            transform.SetAsLastSibling();
            Debug.Log($"{gameObject.name} parent set to Canvas.");
        }
        else
        {
            Debug.LogError($"Canvas is null for {gameObject.name} during OnBeginDrag!", gameObject);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas != null && rectTransform != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // 拖拽位置更新
            Debug.Log($"{gameObject.name} is being dragged to position {rectTransform.anchoredPosition}");
        }
        else
        {
            Debug.LogError($"Canvas or RectTransform is null for {gameObject.name} during OnDrag!", gameObject);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = true; // 恢复检测
            Debug.Log($"CanvasGroup blocksRaycasts re-enabled for {gameObject.name}");
        }
        else
        {
            Debug.LogError($"CanvasGroup is null on {gameObject.name} during OnEndDrag!", gameObject);
        }

        Debug.Log($"OnEndDrag triggered for {gameObject.name}. Final position: {rectTransform.anchoredPosition}");
    }

}
