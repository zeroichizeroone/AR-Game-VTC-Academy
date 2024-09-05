using UnityEngine;
using Vuforia;

public class RotateWithCamera : MonoBehaviour
{
    private Camera vuforiaCamera;

    void Start()
    {
        // Lấy camera của Vuforia
        vuforiaCamera = VuforiaBehaviour.Instance.GetComponent<Camera>();
    }

    void Update()
    {
        // Xoay đối tượng luôn hướng song song với camera của Vuforia
        RotateToCamera();
    }

    void RotateToCamera()
    {
        if (vuforiaCamera != null)
        {
            // Tính toán hướng từ đối tượng tới camera
            Vector3 directionToCamera = vuforiaCamera.transform.position - transform.position;

            // Loại bỏ thành phần chiều cao (y) để chỉ xoay theo mặt phẳng XZ
            directionToCamera.y = 0;

            // Tính toán góc quay cần thiết để đối tượng xoay mặt song song với camera
            Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera);

            // Gán góc quay cho đối tượng
            transform.rotation = targetRotation;
        }
    }
}
