using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StageProcess : MonoBehaviour
{
    GameManager gameManager;
    private float uTime;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        uTime = gameManager.gTime;
    }
}
