using UnityEngine;

public class Player : MonoBehaviour
{
    #region === �⺻ ���� ===
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

    private void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        TriggerFire();
        HPRegeneration();
        HPtrim();
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Player �̵� �Լ� (FixedUpdate)
    /// </summary>
    void Move()
    {
        // Ű �Է°� �ޱ�
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // ���� ����
        Vector2 dir = new(h, v);
        dir.Normalize();

        // �̵�
        transform.Translate(dir * 5f * (1f + speed * 0.01f) * Time.deltaTime);
    }

    /// <summary>
    /// ���� ���⸦ �߻��ϴ� �Լ� (Update)
    /// </summary>
    void TriggerFire()
    {
        if (Input.GetMouseButton(0) == true)
        {
            // ���Ⱑ ���콺�� �ٶ�
            WeaponDir[] weaponDir = GetComponentsInChildren<WeaponDir>();
            for (int i = 0; i < weaponDir.Length; i++)
            {
                weaponDir[i].LookCursor();
            }
            // �Ѿ��� �߻��
            Weapon[] weaponFire = GetComponentsInChildren<Weapon>();
            for (int i = 0; i < weaponFire.Length; i++)
            {
                weaponFire[i].Fire(damage, rangedDamage, critChance, attackSpeed, lifeSteal);
            }
        }
    }

    /// <summary>
    /// �ڵ� ������ ���� �Լ� (������)
    /// </summary>
    public void AutoFire()
    {
        Weapon[] weaponFire = GetComponentsInChildren<Weapon>();
        for (int i = 0; i < weaponFire.Length; i++)
        {
            weaponFire[i].Fire(damage, rangedDamage, critChance, attackSpeed, lifeSteal);
        }
    }

    /// <summary>
    /// ���� ü�� ���� �Լ� (Update)
    /// </summary>
    void HPtrim()
    {
        Mathf.Clamp(currentHP, 0f, maxHP);
    }

    /// <summary>
    /// ü�� ��� �Լ� (Update)
    /// </summary>
    void HPRegeneration()
    {
        // ü���� ��� ���� ���
        if (currentHP < maxHP)
        {
            currentHP += hPRegen * 0.01f;
        }
    }

    /// <summary>
    /// �÷��̾ ���� ����� ��� �Լ� (������)
    /// </summary>
    /// <param name="enemyDamage"></param>
    public void Damaged(float enemyDamage)
    {
        // �÷��̾ ���ߴ���
        bool isPlayerDodge = Random.Range(0f, 100f) <= dodge;

        if (isPlayerDodge)
        {
            // �÷��̾ ����
        }
        else
        {
            // �α� �Լ��� ���� ȿ�� ���������� �ٲٱ� ========================================================
            // ���� ���� �� ����� ���
            currentHP -= enemyDamage * (1 - armor * 0.04f);
        }

        // ����
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}