using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletDamage = 0f;
    public float bulletLifeSteal = 0f;
    public int bulletPierce = 0;

    float movedDistance = 0;
    float bulletRange = 0;

    private void Update()
    {
        if (movedDistance >= bulletRange)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        movedDistance += bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (bulletPierce == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                bulletPierce--;
            }

            bool isLifeSteal = Random.Range(0f, 100f) <= bulletLifeSteal;
            if (isLifeSteal)
            {
                GameObject.Find("Player").GetComponent<Player>().currentHP += 1f;
            }

            collision.gameObject.GetComponent<Enemy>().Damaged(bulletDamage);
        }
    }

    public void SetBulletRange(float range)
    {
        bulletRange = range;
    }
}
