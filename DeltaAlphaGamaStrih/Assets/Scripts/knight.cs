using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    public float shotSpeed;
    public float shotSpeed1;
    public float shotSpeed2;
    public Transform attackPos;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public LayerMask Player;
    public float attackradius1;
    public float attackradius2;
    public float attackradius3;
    public float damage;


    void Start()
    {
        
    }

    void Update()
    {
        CheckAttack();    
    }

    void CheckAttack()
    {
        Collider2D col = null;

            col = Physics2D.OverlapCircle(attackPos.transform.position, attackradius1, Player);
            if (col != null)
            {
                damage = 10;
                col.GetComponent<healthControler>().TakeDamage(damage);
                StartCoroutine(ShotDelay());
                return;
            }
            col = Physics2D.OverlapCircle(attackPos.transform.position, attackradius2, Player);
            if (col != null)
            {
                damage = 20;
                col.GetComponent<healthControler>().TakeDamage(damage);
                StartCoroutine(ShotDelay1());
                return;
            }
            col = Physics2D.OverlapCircle(attackPos.transform.position, attackradius3, Player);
            if (col != null)
            {
                damage = 30;
                col.GetComponent<healthControler>().TakeDamage(damage);
                StartCoroutine(ShotDelay2());
                return;
            }
        }
    

    IEnumerator ShotDelay()
    { 
        yield return new WaitForSeconds(shotSpeed);
    }
    IEnumerator ShotDelay1()
    { 
        yield return new WaitForSeconds(shotSpeed1);
    }
    IEnumerator ShotDelay2()
    { 
        yield return new WaitForSeconds(shotSpeed2);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackradius1);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackradius2);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(attackPos.position, attackradius3);
    }
}
