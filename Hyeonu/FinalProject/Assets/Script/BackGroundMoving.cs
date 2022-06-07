using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoving : MonoBehaviour
{
    // Start is called before the first frame update

    private MeshRenderer render;
    private float offset;
    public float speed;
    private float time;
    private float realTime;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        realTime = ((int)time % 60);
        //Debug.Log(realTime);
        if (realTime <= 10)
            speed = 1;

        else if (realTime > 10 && realTime <= 30)
            speed = 1.1f;

        else if (realTime > 30 && realTime <= 60)
            speed = 1.2f;

        else if (realTime > 60 && realTime <= 90)
            speed = 1.4f;

        offset += Time.deltaTime * speed;
       
        render.material.mainTextureOffset = new Vector2(0, offset);
    }
}
