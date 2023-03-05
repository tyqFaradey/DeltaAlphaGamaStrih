using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    
    //напиши здесь вместо GameObject тип скрипта, который есть на игроке. Так будет проще
    public GameObject player;

    //скорость стрельбы
    public float shotSpeed = 1.5f;
    //может ли стрелять
    public bool canShoot = true;
    //Дальность стрельбы
    public float shotDistance = 5;
    void Start()
    {
        canShoot = true; // изначально может стрелять
        //Player - скрипт, который есть на игроке. Этой строчкой ищем игрока на сцене
        //player = FindObjectOfType<Player>(); 
    }

    void Update()
    {
        if (canShoot && Vector2.Distance(transform.position, player.transform.position) <= shotDistance)
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }

    IEnumerator ShootingDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotSpeed);
        canShoot = true;
    }
}
