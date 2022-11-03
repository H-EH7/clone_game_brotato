using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    GameObject Enemy;

    float currentTime;

    void Update()
    {
        GenerateEnemy();
    }

    // Enemy 오브젝트를 랜덤한 위치에서 생성하는 함수
    void GenerateEnemy()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 5f)
        {
            currentTime = 0;
            Vector2 genPosition = new(Random.Range(-8f, 8f), Random.Range(-5f, 5f));
            Instantiate(Enemy, genPosition, transform.rotation);
        }
    }
}
