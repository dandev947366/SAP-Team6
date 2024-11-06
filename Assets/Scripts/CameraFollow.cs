using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 目标，即角色的位置
    public Vector3 offset = new Vector3(0, 0, -10); // 相机与角色的偏移，默认 -10 保持相机在2D模式下
    public float smoothSpeed = 0.125f; // 平滑速度

    private void LateUpdate()
    {
        if (target == null) return;

        // 计算目标位置
        Vector3 desiredPosition = target.position + offset;

        // 使用 Lerp 平滑移动相机到目标位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
