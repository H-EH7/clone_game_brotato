using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy;

    float currentTime;

    // Update is called once per frame
    void Update()
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
