using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject Quad1;
    public GameObject Quad2;
    public GameObject Quad3;
    public GameObject Quad4;


    GameManager gameManager;
    private float time;

    void Start()
    {
        
    }

    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        time = gameManager.gTime;
 

        if (time > 30 && time < 60)
        {
            Quad1.SetActive(false);
            Quad2.SetActive(true);
        }
        else if(time >= 60 && time < 120)
        {
            Quad2.SetActive(false);
            Quad3.SetActive(true);
        }
        else if(time >= 120)
        {
            Quad3.SetActive(false);
            Quad4.SetActive(true);
        }
    }
}
