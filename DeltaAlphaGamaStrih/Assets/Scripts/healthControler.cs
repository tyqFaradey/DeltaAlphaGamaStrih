using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthControler : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public bool isInvulnerable;
    public float invTime = 1.5f;

    public float hp, maxHp;
    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isInvulnerable = false;
        hp = maxHp;
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
