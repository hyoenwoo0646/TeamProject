using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{

    public Slider hPBar;
    public float maxHP = 0.0f;
    private float minusHp = 0.0f;
    private float time = 0.0f;          // 시간 변수 
    public Text hpText;                 
    public Text timeText;             
   

    void Start()
    {
        minusHp = 1 / maxHP;
    }


    void Update()
    {
        //timeText.text = string.Format("{0:f2}", time += Time.deltaTime);
       // hpText.text = string.Format("HP : {0:f2}", (hPBar.value) * 100);
        hPBar.value -= minusHp * Time.deltaTime;
    }
}
   