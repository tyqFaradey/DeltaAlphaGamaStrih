using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthControler : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer vign;

    public bool isInvulnerable;
    public float invTime = 1.5f;

    public float hp, maxHp;
    public float jumpForce;

    float r = 1, g = 1, b = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isInvulnerable = false;
        hp = maxHp;
    }

    void Update()
    {
        vign.color = new Color(r, g, b, 1);
        if (g < 1) { g += 0.02f; }
        if (b < 1) { b += 0.02f; }
    }

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invTime);
        isInvulnerable = false;
    }

    public void TakeDamage(float damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        hp -= damage;

        g = 0; b = 0;

        if (hp <= 0)
        {
            Destroy(gameObject);
            StartCoroutine(Die());
            //anim.SetTrigger("death");
        }

        else
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            StartCoroutine(Invulnerability());
            //anim.SetTrigger("hit");
        }
    }

    public IEnumerator Die()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Destroy(rb);

        yield return new WaitForSeconds(2);

        /*
        UIManager ui = FindObjectOfType<UIManager>();
        ui.GameOver();
        */
    }
}
