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
            var dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            shootingPoint.eulerAngles = new Vector3(0, 0, angle);
            Instantiate(bulletPrefab, new Vector3(shootingPoint.position.x, shootingPoint.position.y, 0), shootingPoint.rotation);
            StartCoroutine(ShootingDelay());
        }
    }

    IEnumerator ShootingDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotSpeed);
        canShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(shootingPoint.position, shotDistance);
    }
}
