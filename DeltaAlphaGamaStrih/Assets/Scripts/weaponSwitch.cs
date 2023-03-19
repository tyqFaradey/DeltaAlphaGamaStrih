using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour
{
    public List<GameObject> weapons;
    public int curWeapon = 0;

    private void Start()
    {
        foreach (var weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[curWeapon].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        weapons[curWeapon].SetActive(false);
        curWeapon = (curWeapon + 1) % weapons.Count;
        weapons[curWeapon].SetActive(true);
    }

    public void AddWeapon(GameObject weapon)
    {
        foreach (var component in weapon.GetComponents<MonoBehaviour>())
        {
            component.enabled = true;
        }
        weapon.GetComponent<Collider2D>().enabled = false;

        weapon.transform.parent = transform;
        weapon.transform.localPosition = new Vector3(0.6f, 0.483f, 0);

        weapons.Add(weapon);
        weapons[curWeapon].SetActive(false);
        curWeapon = weapons.Count - 1;
        weapons[curWeapon].SetActive(true);
    }
}