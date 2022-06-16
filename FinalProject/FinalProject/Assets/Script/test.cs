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
    public float Damage;
    public float Healing;


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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet") //에너미는 적, 에너미불렛은 총알
        {
            hPBar.value -= Damage;
        }

        if (collision.gameObject.tag == "Item")
        {
            hPBar.value += Healing;
        }
    }
}
   