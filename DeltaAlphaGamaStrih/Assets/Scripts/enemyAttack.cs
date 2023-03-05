using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

    public float damage = 10;
    public LayerMask playerMask;
    public float attackDelay = 1;
    public float attackRadius = 1.5f;

    private bool canAttack;
    void Start()
    {
        canAttack = true;
    }

    
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (!canAttack) { return; }

        var col = Physics2D.OverlapCircle(transform.position, attackRadius, playerMask);
        
        if (col != null)
        {
            col.GetComponent<healthControler>().TakeDamage(damage);
            StartCoroutine(AttackDelay());
        }
    }

    IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

}
