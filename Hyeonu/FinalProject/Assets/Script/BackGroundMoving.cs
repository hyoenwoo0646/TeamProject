using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoving : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Transform[] backgrounds;

    float leftPosX = 0f;
    float rightPosX = 0f;
    float xScreenHalfSize;
    float yScreenHalfSize;

    void Start()
    {
        //화면 좌표 값 초기화
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            if(backgrounds[i].position.x < leftPosX)
            {
                Vector3 nextPos = backgrounds[i].position;
            }
        }
    }
}
