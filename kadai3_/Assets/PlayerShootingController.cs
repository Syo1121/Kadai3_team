using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShootingController : MonoBehaviour
{
    public GameObject shotPrefab; //�e�̃v���n�u
    public float shotSpeed = 8.0f;�@//�e�̑��x

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();�@//�e�̔��˂���
        }
    }

    void Shoot()
    {
        //�}�E�X�̒P�ʂ����[���h���W�Ɍ�������
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        //�v���C���[����}�E�X�̕����ւ̃x�N�g�����v�Z���A���K������
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        //�e���v���C���[�̒P�ʂɐ�������
        GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * shotSpeed;
    }
}
