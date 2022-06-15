using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Quad1;
    public GameObject Quad2;

    GameManager gameManager;
    private float time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        time = gameManager.gTime;
 

        if (time > 30)
        {
            Quad1.SetActive(false);
            Quad2.SetActive(true);
        }
    }
}
