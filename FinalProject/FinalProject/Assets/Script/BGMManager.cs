using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject BackGroundMusic;
    AudioSource bgm;

    void Awake()
    {
        BackGroundMusic = GameObject.Find("BackGroundMusic");
        bgm = BackGroundMusic.GetComponent<AudioSource>();

        if (bgm.isPlaying)
            return;

        else
        {
            bgm.Play();
            DontDestroyOnLoad(bgm);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
