using UnityEngine;

public class CrosshairRaycast : MonoBehaviour
{
    // Tạo tâm ngắm
    public Texture2D crosshairTexture;
    public float crosshairSize = 20f;
    // Khoảng cách raycast
    public float raycastRange = 100f;

    private Camera mainCamera;

    void Start()
    {
        // Lấy camera chính
        mainCamera = Camera.main;
    }

    // Hàm bắn raycast từ tâm màn hình
    public void ShootRayFromCenter()
    {
        // Tính toán tâm của màn hình (trong không gian viewport)
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        // Bắn ray từ camera
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        // Nếu raycast trúng vật thể nào đó
        if (Physics.Raycast(ray, out RaycastHit hitInfo, raycastRange))
        {
            // Debug thông tin về vật thể bị trúng
            Debug.Log("Hit: " + hitInfo.collider.gameObject.name);

            // Làm gì đó với vật thể bị trúng
            Destroy(hitInfo.collider.gameObject);
        }
        else
        {
            Debug.Log("No hit");
        }
    }
}
