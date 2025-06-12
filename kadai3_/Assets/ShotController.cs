using UnityEngine;

public class ShotController : MonoBehaviour
{
    public float rotationSpeed = -1000f;�@ //�e�̉�]���x
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�e�����Z���𒆐S�ɉ�]����
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //���̃I�u�W�F�N�g�ƐڐG�����Ƃ��̏���
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
