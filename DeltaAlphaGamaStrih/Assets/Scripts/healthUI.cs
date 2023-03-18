using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    public healthControler hp;
    public Image bar;

    void Start()
    {
        hp = FindObjectOfType<healthControler>();
    }

    void Update()
    {
        bar.fillAmount = hp.hp / hp.maxHp;
    }
}
