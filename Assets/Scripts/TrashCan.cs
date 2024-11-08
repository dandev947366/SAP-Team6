using UnityEngine;

public class TrashCan : MonoBehaviour, IInteractable
{
    public GameObject[] items; // 可以掉落的物品预制件数组
    public int minItems = 1; // 最小掉落数量
    public int maxItems = 5; // 最大掉落数量

    // 实现接口中的 Interact 方法
    public void Interact()
    {
        Debug.Log("TrashCan Interact called"); // 调试日志

        int itemCount = Random.Range(minItems, maxItems + 1); // 随机生成掉落的物品数量

        for (int i = 0; i < itemCount; i++)
        {
            // 随机选择一个物品
            GameObject item = items[Random.Range(0, items.Length)];

            // 生成随机的掉落位置
            Vector3 dropPosition = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

            // 在场景中实例化物品
            Instantiate(item, dropPosition, Quaternion.identity);
            Debug.Log("Item dropped at position: " + dropPosition); // 调试日志
        }

        // 爆出物品后销毁垃圾桶
        Destroy(gameObject);
        Debug.Log("TrashCan destroyed");

    }
}
