using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRadius;
    public float damage;
    // public Animator anim;

    void Update()
    {

        if (timeBtwAttack <= 0)
        {

            if (Input.GetMouseButton(0))
            {
                // anim.SetTrigger("attack");
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRadius, enemy);
                
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<healthControler>().TakeDamage(damage);
                }

            }

            timeBtwAttack = startTimeBtwAttack;

        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }
}
