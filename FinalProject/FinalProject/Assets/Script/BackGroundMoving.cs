using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoving : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;

    private MeshRenderer render;
    private float offset;
    public float speed;
    private float time;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //�ð� �޾ƿ���
        time = gameManager.gTime;

        if (time <= 10) //�ð����� ��� �ӵ� ����
            speed = 0.4f;

        else if (time > 10 && time <= 30)
            speed = 0.5f;

        else if (time > 30 && time <= 60)
            speed = 0.6f;

        else if (time > 60 && time <= 90)
            speed = 0.7f;

        else if (time > 90)
            speed = 0.8f;


        offset += Time.deltaTime * speed;
       
        render.material.mainTextureOffset = new Vector2(0, offset); //�ӵ���ŭ ������ ����
    }
}
