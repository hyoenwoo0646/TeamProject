using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    GameManager gameManager;

    public Slider hPBar;
    public float maxHP = 0.0f;
    private float minusHp = 0.0f;
    //private float time = 0.0f;          // �ð� ���� 
    //public Text hpText;
    //public Text timeText;
    public float Damage;
    public float Healing;


    void Start()
    {
        minusHp = 1 / maxHP;
    }


    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hPBar.value -= minusHp * Time.deltaTime;
        if(hPBar.value <= 0)
        {
            gameManager.endGame();
            gameManager.gameOver();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy") //���ʹ̴� ��, ���ʹ̺ҷ��� �Ѿ�
        {
            hPBar.value -= Damage;
        }

        if (collision.gameObject.tag == "Item")
        {
            hPBar.value += Healing;
        }
    }
}
   