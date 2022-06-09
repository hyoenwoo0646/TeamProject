using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, -(Time.deltaTime * speed), 0);

        if(gameObject.transform.position.y <= -8.0f)
        {
            Destroy(gameObject);
        }
    }
}
