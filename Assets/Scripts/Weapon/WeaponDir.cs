using UnityEngine;

public class WeaponDir : MonoBehaviour
{
    GameObject NearestEnemy;

    Quaternion InitialDirection;

    private void Start()
    {
        InitialDirection = transform.rotation;
    }

    private void Update()
    {
        if (NearestEnemy == null && Input.GetMouseButton(0) == false)
        {
            DirectionReset();
        }
    }

    /// <summary>
    /// 플레이어가 직접 마우스로 무기 방향을 설정하는 함수 (참조용)
    /// </summary>
    public void LookCursor()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir
            = new Vector2(transform.position.x - cursorPosition.x,
            transform.position.y - cursorPosition.y);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, angle + 90f);
    }

    /// <summary>
    /// 무기 방향 원위치 함수 (Update)
    /// </summary>
    void DirectionReset()
    {
        transform.rotation = InitialDirection;
    }

    
    // 직접 사격이 아닐 시 무기 사정거리 이내이면 자동 공격
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(0) == false && collision.CompareTag("Enemy"))
        {

            if (NearestEnemy == null)
            {
                NearestEnemy = collision.gameObject;
            }
            else
            {
                float distance1 = (transform.position - NearestEnemy.transform.position).sqrMagnitude;
                float distance2 = (transform.position - collision.transform.position).sqrMagnitude;

                if (distance1 > distance2)
                {
                    NearestEnemy = collision.gameObject;
                }
            }

            Vector2 dir
                = new Vector2(transform.position.x - NearestEnemy.transform.position.x,
                transform.position.y - NearestEnemy.transform.position.y);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + 90f);

            GameObject.Find("Player").GetComponent<Player>().AutoFire();
        }
    }

    // 총알이 무기 사정거리 밖이면 총알 파괴
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}