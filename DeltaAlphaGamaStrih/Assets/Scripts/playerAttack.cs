using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public float damage = 100;
    public float attackDelay = 1;
    public float attackRadius = 1.5f;
    public bool isInvulnerable;
    public float invTime = 1.5f;
    public healthControler takeDamage;

    private bool canAttack;

    void Start()
    {
        canAttack = true;
        isInvulnerable = false;
    }

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invTime);
        isInvulnerable = false;
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (!canAttack) { return; }
        
        if (Input.GetMouseButton(0))
        {
            takeDamage = GetComponent<healthControler>();
            takeDamage.TakeDamage();
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
