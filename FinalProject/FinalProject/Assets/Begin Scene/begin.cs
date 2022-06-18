using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class begin : MonoBehaviour
{
    public GameObject playInfo;
    private bool infoWatch;

    void Start()
    {
        infoWatch = false;
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            if(!infoWatch)
            {
                playInfo.SetActive(true);
                infoWatch = true;
            }
            else
            {
                SceneManager.LoadScene("Load Scene");
            }
        }
    }
}
