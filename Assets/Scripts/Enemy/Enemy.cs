using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region === 적 기본 스탯 ===
    public float maxHP = 1f;
    public float hPIncreasePerWave = 1f;
    public float moveSpeed = 3f;
    public float damage = 1f;
    public float damageIncreasePerWave = 0.6f;
    public int dropCoins = 1;
    public float foodDropRate = 0.01f;
    public float containerDropRate = 0.01f;
    #endregion

    public float currentHP;

    GameObject Target;

    bool isAttackReady = true;

    private void Start()
    {
        currentHP = maxHP;

        // Player를 타겟으로 설정
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (GameObject.Find("Player"))
        {
            Move();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAttackReady && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Attack(collision));
        }
    }

    /// <summary>
    /// 공격을 위한 코루틴 함수
    /// </summary>
    /// <param name="collision"></param>
    /// <returns></returns>
    IEnumerator Attack(Collider2D collision)
    {
        isAttackReady = false;

        // 플레이어 대미지 계산 함수 호출
        collision.gameObject.GetComponent<Player>().Damaged(damage);

        yield return new WaitForSeconds(1f);
        isAttackReady = true;
    }

    /// <summary>
    /// Enemy 이동 함수
    /// </summary>
    void Move()
    {
        // 이동 방향 설정
        Vector2 dir = Target.transform.position - transform.position;
        dir.Normalize();

        // 이동
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 적이 입은 대미지 계산 함수 (참조용)
    /// </summary>
    public void Damaged(float attackDamage)
    {
        currentHP -= attackDamage;

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
