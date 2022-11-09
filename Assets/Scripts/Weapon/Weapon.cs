using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;

    #region === 무기 기본 스탯 ===
    public float damage = 1f;
    public float attackSpeed = 1f; // 1초에 x번 공격
    public float damageScale = 100f;
    public float critChance = 1f;
    public float critDamage = 2f;
    public float range = 5f;
    public float knockback = 0f;
    public float lifeSteal = 0f;
    public int basePrice = 10;
    public int pierce = 0;
    #endregion

    bool isFireReady = true;

    private void Start()
    {
        // 무기 공격 범위 초기화
        GetComponentInParent<CircleCollider2D>().radius = range + GameObject.Find("Player").GetComponent<Player>().range * 0.01f;
    }


    /// <summary>
    /// bullet 발사 함수 (참조용)
    /// </summary>
    /// <param name="playerDmg"></param>
    /// <param name="playerRangedDmg"></param>
    /// <param name="playerCritChance"></param>
    public void Fire(float playerDmg, float playerRangedDmg, float playerCritChance, float playerAttackSpeed, float playerLifeSteal)
    {
        if (isFireReady)
        {
            StartCoroutine(FireByRate(playerDmg, playerRangedDmg, playerCritChance, playerAttackSpeed, playerLifeSteal));
        }
    }

    /// <summary>
    /// 발사 가능 시간을 지연해주는 코루틴 함수
    /// </summary>
    /// <param name="playerDmg"></param>
    /// <param name="playerRangedDmg"></param>
    /// <param name="playerCritChance"></param>
    /// <returns></returns>
    IEnumerator FireByRate(float playerDmg, float playerRangedDmg, float playerCritChance, float playerAttackSpeed, float playerLifeSteal)
    {
        isFireReady = false;
        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);

        // 발사된 총알 대미지 계산
        float bulletDamage = (damage + playerRangedDmg * damageScale * 0.01f) * (1f + playerDmg * 0.01f);

        // 치명타 확률 및 치명타 대미지 적용
        bool isCritical = Random.Range(0f, 100f) <= playerCritChance + critChance;
        if (isCritical)
        {
            bulletDamage *= critDamage;
        }

        // 총알의 체력 흡수 확률
        float bulletLifeSteal = lifeSteal + playerLifeSteal;

        bullet.GetComponent<Bullet>().bulletDamage = bulletDamage;
        bullet.GetComponent<Bullet>().bulletPierce = pierce;
        bullet.GetComponent<Bullet>().bulletLifeSteal = bulletLifeSteal;

        float fireRate = 1 / (attackSpeed * (1 + playerAttackSpeed * 0.01f));
        yield return new WaitForSeconds(fireRate);
        isFireReady = true;
    }
}
