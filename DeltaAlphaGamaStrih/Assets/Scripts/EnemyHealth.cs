using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hp, maxHp;
    //public Animator anim;
    SpriteRenderer sr;

    void Start()
    {
        hp = maxHp;   
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
            //anim.SetTrigger("death");
        }
        else
        {
            //anim.SetTrigger("hit");
        }
    }

    public void Die()
    {
        for (int i = 0; i < 100; i++) { Invoke("Diiiiieeee()", 0.1f); }
        Destroy(gameObject);
    }

    void Diiiiieeee()
    {
            sr.color = new Color(0, 0, 0, 0);
            print(sr.color);
    }
}
