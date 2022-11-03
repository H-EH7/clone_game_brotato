using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float fMoveSpeed = 5f;

    void FixedUpdate()
    {
        Move();

    }

    // Player �̵� �Լ�
    void Move()
    {
        // Ű �Է°� �ޱ�
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // ���� ����
        Vector2 dir = new(h, v);
        dir.Normalize();

        // �̵�
        transform.Translate(dir * fMoveSpeed * Time.deltaTime);
    }
}
