using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Toggle : MonoBehaviour
{
    public GameObject soundOnImg;
    public GameObject soundOffImg;
    public GameObject soundOnBtn;
    public GameObject soundOffBtn;
    public bool isSoundOn;

    public GameObject musicOnImg;
    public GameObject musicOffImg;
    public GameObject musicOnBtn;
    public GameObject musicOffBtn;
    public bool isMusicOn;

    GameObject BackGroundMusic;
    AudioSource bgm;
    
    void Awake()
    {
        isSoundOn = true;
        isMusicOn = true;
    }

    public void ButtonAction_Sound()
    {
        if(isSoundOn == true)
        {
            soundOnImg.SetActive(false);
            soundOnBtn.SetActive(false);
            soundOffImg.SetActive(true);
            soundOffBtn.SetActive(true);
            isSoundOn = false;
        }
        else
        {
            soundOnImg.SetActive(true);
            soundOnBtn.SetActive(true);
            soundOffImg.SetActive(false);
            soundOffBtn.SetActive(false);
            isSoundOn = true;
        }
    }
    
    public void ButtonAction_Music()
    {
        BackGroundMusic = GameObject.Find("BackGroundMusic");
        bgm = BackGroundMusic.GetComponent<AudioSource>();
        if(bgm.isPlaying == true)
        {
            musicOnImg.SetActive(false);
            musicOnBtn.SetActive(false);
            musicOffImg.SetActive(true);
            musicOffBtn.SetActive(true);
            bgm.Pause();
        }
        else
        {
            musicOnImg.SetActive(true);
            musicOnBtn.SetActive(true);
            musicOffImg.SetActive(false);
            musicOffBtn.SetActive(false);
            bgm.Play();
        }
    }
}
