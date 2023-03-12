using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    public GameObject attackPos;
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
        if (timeBtwAttack <= 0)
        {
            col = Physics2D.OverlapCircle(attackPos.transform.position, attackradius1, Player);
            if (col != null)
            {
                //jsdjsdjlksd
                return;
            }
            col = Physics2D.OverlapCircle(attackPos.transform.position, attackradius2, Player);
            if (col != null)
            {
                //lksdkjkl;sdgjkldfgkldf
                return;
            }
            col = Physics2D.OverlapCircle(attackPos.transform.position, attackradius3, Player);
            if (col != null)
            {
                //lksdkjkl;sdgjkldfgkldf
                return;
            }
        }
    }
}
