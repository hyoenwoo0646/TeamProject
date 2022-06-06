using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Quad1;
    public GameObject Quad2;
    private float time;
    private float realTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        realTime = ((int)time % 60);

        if (realTime > 30)
        {
            Quad1.SetActive(false);
            Quad2.SetActive(true);
        }
    }
}
