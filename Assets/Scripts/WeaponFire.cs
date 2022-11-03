using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;

    // 무기 공격속도
    const float fireSpeed = 1f;

    float currentTime = fireSpeed;

    private void Update()
    {
        currentTime = Mathf.Clamp(currentTime+Time.deltaTime, 0f, 1f);
    }

    // bullet 발사 함수
    public void Fire()
    {
        if (currentTime>= fireSpeed)
        {
            currentTime = 0f;
            Instantiate(Bullet, transform.position, transform.rotation);
            return;
        }
        return;
    }
}
