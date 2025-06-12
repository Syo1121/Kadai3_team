using UnityEngine;

public class SeamlessDiagonalScroller : MonoBehaviour
{
    [Header("Scrolling Settings")]
    [SerializeField]
    private float scrollSpeed = 2f; // ความเร็วในการเลื่อน

    [SerializeField]
    private Vector2 scrollDirection = new Vector2(1f, -1f).normalized; // ทิศทางการเลื่อน (เฉียงลงขวา)
                                                                       // .normalized เพื่อให้ความเร็วคงที่ ไม่ว่าจะเฉียงไปทางไหน

    [Header("Tilemaps for Looping")]
    [SerializeField]
    private Transform tilemap1; // Tilemap ชุดแรก (เช่น Background_A)
    [SerializeField]
    private Transform tilemap2; // Tilemap ชุดที่สอง (เช่น Background_B)

    [Header("Looping Dimensions")]
    [SerializeField]
    private Vector2 tilemapDimensions = new Vector2(20f, 20f); // ขนาดของ Tilemap ในหน่วย World Space
                                                               // (ความกว้างและความสูงของ Tilemap ที่ใช้ในการวนลูป)

    private Vector3 resetPositionOffset; // ค่าชดเชยสำหรับการรีเซ็ตตำแหน่ง

    void Start()
    {
        if (tilemap1 == null || tilemap2 == null)
        {
            Debug.LogError("กรุณากำหนด Tilemap 1 และ Tilemap 2 ใน Inspector ของ SeamlessDiagonalScroller.");
            enabled = false; // ปิด Script ถ้าไม่ได้กำหนด Tilemap
            return;
        }

        // คำนวณค่าชดเชยการรีเซ็ตตำแหน่ง
        // เช่น ถ้าเลื่อนลงขวา (1, -1) และขนาด 20x20
        // resetPositionOffset จะเป็น (20, -20, 0)
        resetPositionOffset = new Vector3(tilemapDimensions.x * scrollDirection.x,
                                          tilemapDimensions.y * scrollDirection.y,
                                          0f);
    }

    void Update()
    {
        // คำนวณการเคลื่อนที่ในเฟรมนี้
        Vector3 movement = (Vector3)scrollDirection * scrollSpeed * Time.deltaTime;

        // เคลื่อนย้าย Tilemap ทั้งสองพร้อมกัน
        tilemap1.Translate(movement);
        tilemap2.Translate(movement);

        // ตรวจสอบและรีเซ็ตตำแหน่งเพื่อสร้างการวนลูป
        CheckAndResetTilemaps();
    }

    private void CheckAndResetTilemaps()
    {
        // ตรวจสอบ Tilemap 1
        if (ShouldReset(tilemap1.position, tilemap2.position))
        {
            // ย้าย Tilemap 1 ไปวางต่อท้าย Tilemap 2
            tilemap1.position = tilemap2.position + resetPositionOffset;
        }
        // ตรวจสอบ Tilemap 2
        else if (ShouldReset(tilemap2.position, tilemap1.position))
        {
            // ย้าย Tilemap 2 ไปวางต่อท้าย Tilemap 1
            tilemap2.position = tilemap1.position + resetPositionOffset;
        }
    }

    private bool ShouldReset(Vector3 currentTilemapPos, Vector3 otherTilemapPos)
    {
        // ตรวจสอบตามทิศทาง X
        if (scrollDirection.x > 0 && currentTilemapPos.x > otherTilemapPos.x + tilemapDimensions.x)
        {
            return true;
        }
        else if (scrollDirection.x < 0 && currentTilemapPos.x < otherTilemapPos.x - tilemapDimensions.x)
        {
            return true;
        }

        // ตรวจสอบตามทิศทาง Y
        if (scrollDirection.y > 0 && currentTilemapPos.y > otherTilemapPos.y + tilemapDimensions.y)
        {
            return true;
        }
        else if (scrollDirection.y < 0 && currentTilemapPos.y < otherTilemapPos.y - tilemapDimensions.y)
        {
            return true;
        }
        return false;
    }

    // ฟังก์ชันสำหรับวาด Gizmo เพื่อช่วยในการตั้งค่าขนาดของ Tilemap
    void OnDrawGizmos()
    {
        if (tilemap1 != null && tilemap2 != null)
        {
            Gizmos.color = Color.cyan;
            // วาดกรอบแสดงขนาดของ Tilemap ที่ใช้ในการวนลูป
            Gizmos.DrawWireCube(tilemap1.position, new Vector3(tilemapDimensions.x, tilemapDimensions.y, 0f));
            Gizmos.DrawWireCube(tilemap2.position, new Vector3(tilemapDimensions.x, tilemapDimensions.y, 0f));

            Gizmos.color = Color.blue;
            // วาดทิศทางการเลื่อน
            Gizmos.DrawLine(tilemap1.position, tilemap1.position + (Vector3)scrollDirection * 5f);
        }
    }
}

