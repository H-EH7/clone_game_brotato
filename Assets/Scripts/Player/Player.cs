using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region === 기본 스탯 ===
    public float maxHP = 10;
    public float hPRegen = 0;
    public float lifeSteal = 0;
    public float damage = 0;
    public float meleeDamage = 0;
    public float rangedDamage = 0;
    public float elementalDamage = 0;
    public float attackSpeed = 0;
    public float critChance = 0;
    public float engineering = 0;
    public float range = 0;
    public float armor = 0;
    public float dodge = 0;
    public float speed = 0;
    public float luck = 0;
    public float harvesting = 0;
    #endregion

    public float currentHP;

    bool isDamaged = false;

    private void Start()
    {
        currentHP = maxHP;
        HPBar.instance.InitHPBar();
    }

    private void Update()
    {
        TriggerFire();
        HPTrim();
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Player 이동 함수 (FixedUpdate)
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
        transform.Translate(dir * 5f * (1f + speed * 0.01f) * Time.deltaTime);
    }

    /// <summary>
    /// 직접 무기를 발사하는 함수 (Update)
    /// </summary>
    void TriggerFire()
    {
        if (Input.GetMouseButton(0) == true && Time.timeScale != 0f)
        {
            // 무기가 마우스를 바라봄
            WeaponDir[] weaponDir = GetComponentsInChildren<WeaponDir>();
            for (int i = 0; i < weaponDir.Length; i++)
            {
                weaponDir[i].LookCursor();
            }
            // 총알이 발사됨
            Weapon[] weaponFire = GetComponentsInChildren<Weapon>();
            for (int i = 0; i < weaponFire.Length; i++)
            {
                weaponFire[i].Fire(damage, rangedDamage, critChance, attackSpeed, lifeSteal);
            }
        }
    }

    /// <summary>
    /// 자동 공격을 위한 함수 (참조용)
    /// </summary>
    public void AutoFire(Weapon weapon)
    {
        weapon.Fire(damage, rangedDamage, critChance, attackSpeed, lifeSteal);
    }

    void HPTrim()
    {
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP);
    }

    /// <summary>
    /// 체력 재생 함수 (Update)
    /// </summary>
    IEnumerator HPRegeneration()
    {
        while (isDamaged)
        {
            yield return new WaitForSeconds(1f);
            currentHP += hPRegen * 0.01f;
            if (currentHP >= maxHP)
            {
                isDamaged = false;
            }
        }
    }

    /// <summary>
    /// 플레이어가 입은 대미지 계산 함수 (참조용)
    /// </summary>
    /// <param name="enemyDamage"></param>
    public void Damaged(float enemyDamage)
    {
        // 플레이어가 피했는지
        bool isPlayerDodge = Random.Range(0f, 100f) <= dodge;

        if (isPlayerDodge)
        {
            // 플레이어가 피함
        }
        else
        {
            // 로그 함수로 점차 효과 떨어지도록 바꾸기 ========================================================
            // 방어력 적용 후 대미지 계산
            currentHP -= enemyDamage * (1 - armor * 0.04f);
            if (isDamaged == false)
            {
                isDamaged = true;
                StartCoroutine(HPRegeneration());
            }
        }

        // 죽음
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
