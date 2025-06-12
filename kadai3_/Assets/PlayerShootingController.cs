using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShootingController : MonoBehaviour
{
    public GameObject shotPrefab; //弾のプレハブ
    public float shotSpeed = 8.0f;　//弾の速度

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();　//弾の発射する
        }
    }

    void Shoot()
    {
        //マウスの単位をワールド座標に交換する
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        //プレイヤーからマウスの方向へのベクトルを計算し、正規化する
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        //弾をプレイヤーの単位に生成する
        GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * shotSpeed;
    }
}
