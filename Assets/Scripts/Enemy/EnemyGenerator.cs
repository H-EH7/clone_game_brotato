using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy;

    [SerializeField]
    float enemyGenTime = 5f;

    bool isEnemyReady = true;

    public float mapMaxX = 21f;
    public float mapMinX = -21f;
    public float mapMaxY = 15f;
    public float mapMinY = -15f;

    void Update()
    {
        if (GameObject.Find("Player"))
        {
            StartCoroutine(GenerateEnemy());
        }
    }

    /// <summary>
    /// Enemy 오브젝트를 랜덤한 위치에서 생성하는 코루틴 함수
    /// </summary>
    IEnumerator GenerateEnemy()
    {
        if (isEnemyReady)
        {
            isEnemyReady = false;
            Vector2 genPosition = new(Random.Range(mapMinX, mapMaxX), Random.Range(mapMinY, mapMaxY));
            Instantiate(Enemy, genPosition, transform.rotation);
            yield return new WaitForSeconds(enemyGenTime);
            isEnemyReady = true;
        }
    }
}
