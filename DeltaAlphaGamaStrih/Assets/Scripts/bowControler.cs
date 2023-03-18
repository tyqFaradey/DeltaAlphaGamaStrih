using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowControler : MonoBehaviour
{
    public float shotSpeed = 0.5f;
    public GameObject bulletPrefab;
    public float angleSpreading = 5f;

    public Transform gunPoint;

    public bool canShoot;
    public bool canAttack = true;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if (canAttack)
        {
            Rotate();
            CheckShot();
        }
    }

    void CheckShot()
    {
        if (!(Input.GetMouseButton(0) && canShoot))
        {
            return;
        }

        var bullet = Instantiate(bulletPrefab, gunPoint.position, transform.rotation);

        float angle = bullet.transform.eulerAngles.z;
        angle += Random.Range(-angleSpreading, angleSpreading);
        bullet.transform.eulerAngles = new Vector3(0, 0, angle-90);

        StartCoroutine(ShotDelay());
    }

    IEnumerator ShotDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotSpeed);
        canShoot = true;
    }

    void Rotate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, angle+90);
    }

    private void OnEnable()
    {
        if (!canShoot)
        {
            StartCoroutine(ShotDelay());
        }
    }
}
