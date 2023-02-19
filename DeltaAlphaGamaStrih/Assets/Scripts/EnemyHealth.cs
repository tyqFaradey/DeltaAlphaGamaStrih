using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hp, maxHp;
    //public Animator anim;

    void Start()
    {
        hp = maxHp;        
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
        Destroy(gameObject);
    }
}
