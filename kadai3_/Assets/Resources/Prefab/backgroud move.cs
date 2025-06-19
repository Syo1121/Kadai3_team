using UnityEngine;





public class SeamlessScroller : MonoBehaviour

{

    [Tooltip("ความเร็วในการเลื่อนลง")]

    public float scrollSpeed = 2.0f;



    [Tooltip("ความสูงของวัตถุนี้ (แกน Y) ต้องกำหนดค่าให้ถูกต้อง")]

    public float objectHeight;



    private Vector3 startPosition;



    void Start()

    {

        // เก็บตำแหน่งเริ่มต้นของวัตถุไว้

        startPosition = transform.position;

    }



    void Update()

    {

        // ทำให้วัตถุเลื่อนลงอย่างต่อเนื่องและคงที่ตามเวลาจริง

        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);



        // คำนวณจุดที่จะให้วัตถุวาร์ปกลับไปด้านบน

        // เมื่อวัตถุเลื่อนลงมาต่ำกว่าตำแหน่งเริ่มต้นลบด้วยความสูงของมันเอง

        // หมายความว่าวัตถุทั้งชิ้นได้หลุดออกจากตำแหน่งเริ่มต้นไปแล้ว

        if (transform.position.y < startPosition.y - objectHeight)

        {

            // ย้ายวัตถุนี้กลับขึ้นไปด้านบน โดยบวกตำแหน่งปัจจุบันด้วยความสูง 2 เท่า

            // เพื่อให้ไปต่อท้ายของวัตถุอีกชิ้นหนึ่งที่กำลังเลื่อนลงมาพอดี

            transform.position += new Vector3(0, objectHeight * 2, 0);

        }

    }

}