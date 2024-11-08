using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Tooltip("This value represents the amount of money this item gives when collected.")]
    public int value = 1; // 每个物品的金币价值，默认为1

    // 被收集时调用
    public void Collect()
    {
        // 将价值添加到金币总数
        ScoreManager.instance.AddPoint(value);

        Destroy(gameObject); // 收集后销毁物品
    }
}
