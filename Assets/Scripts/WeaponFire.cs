using System.Collections;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;

    // 무기 공격속도
    const float fireRate = 1f;

    bool isFireReady = true;

    /// <summary>
    /// bullet 발사 함수
    /// </summary>
    public void Fire()
    {
        if (isFireReady)
        {
            isFireReady = false;
            StartCoroutine(FireByRate());
        }
        else
        {
            Debug.Log("아직 발사할 수 없습니다.");
        }
    }

    /// <summary>
    /// 발사 가능 시간을 지연해주는 코루틴 함수
    /// </summary>
    /// <returns>WaitForSeconds</returns>
    IEnumerator FireByRate()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(fireRate);
        isFireReady = true;
    }
}
