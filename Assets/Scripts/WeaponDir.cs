using UnityEngine;

public class WeaponDir : MonoBehaviour
{
    GameObject NearestEnemy;

    /// <summary>
    /// 플레이어가 직접 마우스로 무기 방향을 설정할 수 있도록 참조를 위한 함수
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

    
    // 직접 사격이 아닐 시 무기 사정거리 이내이면 자동 공격
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(0) == false)
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

            // Atan2는 탄젠트 값으로 라디안 각도를 구함
            // Rad2Deg는 라디안 값에 곱하면 각도로 변환
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + 90f);
            GetComponentInChildren<WeaponFire>().Fire();
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