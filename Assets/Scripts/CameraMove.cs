using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject player;

    float moveSpeed = 4f;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 0, -10), moveSpeed * Time.deltaTime);
        
        float limitedPositionX = Mathf.Clamp(transform.position.x, -13f, 13f);
        float limitedPositionY = Mathf.Clamp(transform.position.y, -13f, 13f);

        transform.position = new Vector3(limitedPositionX, limitedPositionY, -10f);
    }
}
