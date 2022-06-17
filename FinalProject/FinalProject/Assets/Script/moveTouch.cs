using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTouch : MonoBehaviour
{
    GameObject gameobject;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        gameobject = GameObject.Find("Player2");
        player = gameobject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftBtnDown()
    {
        player.LeftMove = true;
    }
    public void LeftBtnUp()
    {
        player.LeftMove = false;
    }
    public void RightBtnDown()
    {
        player.RightMove = true;
    }
    public void RightBtnUp()
    {
        player.RightMove = false;
    }
}
