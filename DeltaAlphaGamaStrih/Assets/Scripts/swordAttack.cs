using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask Enemy;
    public float attackRudius;
    public float damage;
    public bool canAttack = true;

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            if (timeBtwAttack <= 0)
            {
                if (Input.GetMouseButton(0))

                {
                    Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRudius, Enemy);
                    transform.position = new Vector2(transform.position.x - 1, transform.position.y);

                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                    }
                }

                timeBtwAttack = startTimeBtwAttack;
            }

            else
            {
                timeBtwAttack--;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRudius);
    }

}
