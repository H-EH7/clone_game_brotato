using UnityEngine;

public class WeaponDir : MonoBehaviour
{
    GameObject NearestEnemy;

    // �÷��̾ ���� ���콺�� ���� ������ ������ �� �ֵ��� ������ ���� �Լ�
    public void LookCursor()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir
            = new Vector2(transform.position.x - cursorPosition.x,
            transform.position.y - cursorPosition.y);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, angle + 90f);
    }

    // ���� ����� �ƴ� �� ���� �����Ÿ� �̳��̸� �ڵ� ����
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

            // Atan2�� ź��Ʈ ������ ���� ������ ����
            // Rad2Deg�� ���� ���� ���ϸ� ������ ��ȯ
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + 90f);
            GetComponentInChildren<WeaponFire>().Fire();
        }
    }

    // �Ѿ��� ���� �����Ÿ� ���̸� �Ѿ� �ı�
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}