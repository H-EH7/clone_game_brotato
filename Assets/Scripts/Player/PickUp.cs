using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Vector2 dir = GameObject.Find("Player").transform.position - collision.transform.position;
            collision.transform.Translate(dir * 10f * Time.deltaTime);
        }
    }
}
