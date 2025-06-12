using UnityEngine;

public class ShotController : MonoBehaviour
{
    public float rotationSpeed = -1000f;　 //弾の回転速度
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //弾を常にZ軸を中心に回転する
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //他のオブジェクトと接触したときの処理
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
