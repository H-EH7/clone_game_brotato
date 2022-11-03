using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float moveSpeed = 3f;

    GameObject Target;

    private void Start()
    {
        // Player를 타겟으로 설정
        Target = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        Move();
    }

    // Enemy 이동 함수
    void Move()
    {
        // 이동 방향 설정
        Vector2 dir = Target.transform.position - transform.position;
        dir.Normalize();

        // 이동
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}
