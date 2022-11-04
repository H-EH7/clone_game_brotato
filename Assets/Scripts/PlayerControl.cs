using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        TriggerFire();
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Player 이동 함수
    /// </summary>
    void Move()
    {
        // 키 입력값 받기
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 방향 설정
        Vector2 dir = new(h, v);
        dir.Normalize();

        // 이동
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 직접 무기를 발사하는 함수
    /// </summary>
    void TriggerFire()
    {
        if (Input.GetMouseButton(0))
        {
            // 무기가 마우스를 바라봄
            WeaponDir[] weaponDir = GetComponentsInChildren<WeaponDir>();
            for (int i = 0; i < weaponDir.Length; i++)
            {
                weaponDir[i].LookCursor();
            }
            // 총알이 발사됨
            WeaponFire[] weaponFire = GetComponentsInChildren<WeaponFire>();
            for (int i = 0; i < weaponFire.Length; i++)
            {
                weaponFire[i].Fire();
            }
        }
    }
}
