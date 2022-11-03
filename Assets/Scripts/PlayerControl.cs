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
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    // ���� ���⸦ �߻��ϴ� �Լ�
    void TriggerFire()
    {
        if (Input.GetMouseButton(0))
        {
            // ���Ⱑ ���콺�� �ٶ�
            WeaponDir[] weaponDir = GetComponentsInChildren<WeaponDir>();
            for (int i = 0; i < weaponDir.Length; i++)
            {
                weaponDir[i].LookCursor();
            }
            // �Ѿ��� �߻��
            WeaponFire[] weaponFire = GetComponentsInChildren<WeaponFire>();
            for (int i = 0; i < weaponFire.Length; i++)
            {
                weaponFire[i].Fire();
            }
        }
    }
}
