using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float fMoveSpeed = 3f;

    GameObject Target;

    private void Start()
    {
        // Player�� Ÿ������ ����
        Target = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        Move();
    }

    // Enemy �̵� �Լ�
    void Move()
    {
        // �̵� ���� ����
        Vector2 dir = Target.transform.position - transform.position;
        dir.Normalize();

        // �̵�
        transform.Translate(dir * fMoveSpeed * Time.deltaTime);
    }
}
