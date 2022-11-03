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

    // Player 이동 함수
    void Move()
    {
        // 키 입력값 받기
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 방향 설정
        Vector2 dir = new(h, v);
        dir.Normalize();

        // 이동
        transform.Translate(dir * fMoveSpeed * Time.deltaTime);
    }
}
