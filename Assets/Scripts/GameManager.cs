using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 单例实例
    public int money = 0;

    // 定义事件，用于通知 UI 更新
    public delegate void MoneyChanged(int newAmount);
    public static event MoneyChanged OnMoneyChanged;

    private void Awake()
    {
        // 初始化单例
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 增加金币的方法
    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Money: " + money);

        // 触发金币变化事件
        if (OnMoneyChanged != null)
        {
            OnMoneyChanged(money);
        }
    }
}
