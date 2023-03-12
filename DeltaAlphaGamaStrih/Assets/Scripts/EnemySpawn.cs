using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int enemyPercent = 50;
    public GameObject Blizhnik;
    public GameObject Dalnik;

    void Start()
    {
        if (Random.Range(0, 101) <= enemyPercent)
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(Blizhnik, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(Dalnik, transform.position, transform.rotation);
            }
        }
    }
}
