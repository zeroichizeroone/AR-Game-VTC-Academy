using UnityEngine;

public class RandomBlocksGrid : MonoBehaviour
{
    // Kích thước của từng khối
    public Vector3 blockSize = new Vector3(1, 1, 1);
    // Khoảng cách giữa các khối
    public float spacing = 1.5f;
    // Tag sẽ được gán cho các khối
    public string tagName = "Block";
    // Layer sẽ được gán cho các khối
    public int layer = 0; // Bạn có thể đặt giá trị layer tùy ý

    // Khởi tạo các khối theo dạng lưới 3x3
    void Start()
    {
        // Vòng lặp qua 9 vị trí tạo thành lưới 3x3
        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                // Tính toán vị trí của khối dựa trên vị trí trong lưới
                Vector3 position = new Vector3(x * (blockSize.x + spacing), 0, z * (blockSize.z + spacing));

                // Tạo khối tại vị trí này
                CreateBlock(position);
            }
        }
    }

    // Hàm tạo khối với kích thước và màu ngẫu nhiên
    void CreateBlock(Vector3 position)
    {
        // Tạo khối mới
        GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
        block.transform.parent = transform;

        // Đặt vị trí cho khối
        block.transform.position = position;

        // Gán tag cho khối
        block.tag = tagName;

        // Gán layer cho khối
        block.layer = layer;

        // Kích thước ngẫu nhiên cho khối
        block.transform.localScale = new Vector3(
            Random.Range(0.1f, blockSize.x),
            Random.Range(0.1f, blockSize.y),
            Random.Range(0.1f, blockSize.z)
        );

        // Màu ngẫu nhiên cho khối
        Renderer renderer = block.GetComponent<Renderer>();
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
