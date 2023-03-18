using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthControler : MonoBehaviour
{
    RoomGeneration rg;
    public swordAttack sa;
    public bowControler bc;
    public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer vign;
    public SpriteRenderer die;

    public bool isInvulnerable;
    public float invTime = 1.5f;

    public float hp, maxHp;
    public float jumpForce;

    public float r = 1, g = 1, b = 1, a = 0;

    void Start()
    {
        sa = GetComponent<swordAttack>();
        bc = GetComponent<bowControler>();
        rb = GetComponent<Rigidbody2D>();
        rg = GetComponent<RoomGeneration>();
        isInvulnerable = false;
        hp = maxHp;
    }

    void Update()
    {
        vign.color = new Color(r, g, b, 1);
        die.color = new Color(1, 1, 1, a);
        if (g < 1) { g += 0.02f; }
        if (b < 1) { b += 0.02f; }
        if (hp <= 0) { a += 0.01f; die.color = new Color(1, 1, 1, a); }
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

        if (hp <= 0 & a >= 1)
        {
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
        sa.canAttack = false;
        bc.canAttack = false;


        yield return new WaitForSeconds(2);
    }
}
