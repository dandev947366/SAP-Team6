using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    public GameObject craftingView; // 合成界面
    public GameObject inventoryView; // 背包界面

    private bool isPlayerNearby = false;

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) // 按下交互键
        {
            ToggleCraftingUI();
        }
    }

    private void ToggleCraftingUI()
    {
        bool isActive = craftingView.activeSelf;
        craftingView.SetActive(!isActive);
        inventoryView.SetActive(!isActive);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
