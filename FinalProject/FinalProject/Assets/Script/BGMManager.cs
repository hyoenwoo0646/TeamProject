using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    GameObject BackGroundMusic;
    AudioSource bgm;

    void Awake()
    {
        BackGroundMusic = GameObject.Find("BackGroundMusic");       //bgm 받아오기
        bgm = BackGroundMusic.GetComponent<AudioSource>();

        if (bgm.isPlaying) return;
        else
        {
            bgm.Play();
            DontDestroyOnLoad(bgm);     //씬이 변경되도 로드
        }
    }
    
    public void BGMPlay()
    {
        if(bgm.isPlaying) return;
        
        bgm.Play();
    }

    public void BGMStop()
    {
        bgm.Stop();
    }
}
