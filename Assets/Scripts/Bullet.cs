using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.up * 10f * Time.deltaTime);
    }

    // Enemy Tag�� ���� ������Ʈ�� �ε����� �� ��� �ı�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
