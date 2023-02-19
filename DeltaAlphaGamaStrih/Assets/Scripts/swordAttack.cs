using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRudius;
    public float damage;

    // Update is called once per frame
    void Update()
    {

        if (timeBtwAttack <= 0)

        {

            if (Input.GetMouseButton(0))

            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRudius, enemy);

                for (int i=0; i<enemies.Length; i++)
                
                {
                    enemies[i].GetComponent<healthControler>().TakeDamage(damage);
                }

            }

            timeBtwAttack = startTimeBtwAttack;

        }

        else

        {
            timeBtwAttack -= startTimeBtwAttack;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRudius);
    }

}
