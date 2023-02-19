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
            weapons[curWeapon].SetActive(false);
            curWeapon = (curWeapon + 1) % weapons.Count;
            weapons[curWeapon].SetActive(true);
        }
    }
}
