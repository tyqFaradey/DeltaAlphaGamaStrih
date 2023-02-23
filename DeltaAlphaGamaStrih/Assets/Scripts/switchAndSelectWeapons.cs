using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchAndSelectWeapons : MonoBehaviour
{
    public List<GameObject> unlocedWeapons;
    public GameObject[] allWeapons;
    //public GameObject weaponImage;

    public GameObject sword;
    public GameObject crosbow;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(sword.activeInHierarchy == true & ((IList<GameObject>)unlocedWeapons).Contains(crosbow))
            {
                sword.SetActive(false);
                crosbow.SetActive(true);
            }
            
            else if(crosbow.activeInHierarchy == true)
            {
                sword.SetActive(true);
                crosbow.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < allWeapons.Length; i++)
        {
            if (other.name == allWeapons[i].name)
            {
                unlocedWeapons.Add(allWeapons[i]);
            }
        }
        Destroy(other.gameObject);
    }
}
