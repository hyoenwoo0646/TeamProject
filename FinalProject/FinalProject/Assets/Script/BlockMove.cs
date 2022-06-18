using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    // Start is called before the first frame update

    GameManager gameManager;

    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        float time = gameManager.gTime;
        //시간별로 장애물 속도 증가
        if (time <= 10)
            speed = 4.0f;

        else if (time > 10 && time <= 30)
            speed = 5.0f;

        else if (time > 30 && time <= 60)
            speed = 6.0f;

        else if (time > 60 && time <= 90)
            speed = 7.0f;

        else if (time > 90 && time <= 120)
            speed = 8.5f;

        else if (time > 120)
            speed = 10.0f;

        gameObject.transform.Translate(0, -(Time.deltaTime * speed), 0);

        //if(gameObject.transform.position.y <= -8.0f)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter(Collider collision)     //삭제 함수
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }

    }
}
