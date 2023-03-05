using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    public healthControler hp;
    Image bar;

    void Start()
    {
        bar = GetComponent<Image>();
    }

    void Update()
    {
        bar.fillAmount = hp.hp / hp.maxHp;
    }
}
