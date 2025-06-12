using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timer = 180.0f; // 3 นาที (180 วินาที)
    public TMP_Text countdownText; // ลิงก์ไปยัง TextMesh Pro UI Text

    void Start()
    {
       
        UpdateTimerUI();
    }

    void Update()
    {
        
        timer -= Time.deltaTime;

        // อัปเดต UI
        UpdateTimerUI();

       
        //if (timer <= 0)
       //{
           // SceneManager.LoadScene("ClearScene");
        //}
    }

    void UpdateTimerUI()
    {
        
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        
        countdownText.text = string.Format("Time:{0:00}:{1:00}", minutes, seconds);
    }
}


