using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHitDetection : MonoBehaviour
{

    float timer = 1f;

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && timer <= 0)
        {
            collision.gameObject.SendMessage("ApplyDamage", 10);
            timer = 1f;
        }
    }
}