using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ParticleSystem ps;
    public float MonsterHealt = 30f;
    float timer1 = 10;
    float timer2 = 1f;
    float timer3 = 3f;
    bool IsOver = false;
    bool startTimer = false;
    Rigidbody2D rb;

    public void ApplyDamage(float damage)
    {
        MonsterHealt -= damage;
        if (MonsterHealt <= 0)
        {
            healthBar.setSize(0);
            ps.Play();
            startTimer = true;

        }
    }

    void Update()
    {
        float health;
        if (MonsterHealt > 0)
        {
            health = MonsterHealt / 30;
            healthBar.setSize(health);
        }

        if (timer3 < 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if (startTimer == true)
        {
            timer3 -= Time.deltaTime;
        }
            

        if (timer1 > 0 && IsOver == false)
        {
            rb.velocity = new Vector2(2, rb.velocity.y);
        }
        else if (timer1 < 0 && IsOver == false)
        {
            timer1 = 10;
            IsOver = true;
        }

        if (timer1 > 0 && IsOver == true)
        {
            rb.velocity = new Vector2(-2, rb.velocity.y);
        }
        else if (timer1 < 0 && IsOver == true)
        {
            timer1 = 10;
            IsOver = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero" && timer2 <= 0)
        {
            collision.gameObject.SendMessage("ApplyHeroDamage", 10);
            timer2 = 1f;
        }
    }
}
