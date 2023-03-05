using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchAndSelectWeapons : MonoBehaviour
{
    public weaponSwitch switcher;
    public List<GameObject> unlocedWeapons;
    public GameObject[] allWeapons;
    //public GameObject weaponImage;

    public GameObject sword;
    public GameObject crosbow;

    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < allWeapons.Length; i++)
        {
            if (other.name == allWeapons[i].name)
            {
                unlocedWeapons.Add(allWeapons[i]);
                switcher.AddWeapon(other.gameObject);
            }
        }
        //Destroy(other.gameObject);
    }
}
