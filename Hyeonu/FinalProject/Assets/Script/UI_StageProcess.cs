using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_StageProcess : MonoBehaviour
{
    GameManager gameManager; //gTime 받아오기 (진행도)
    public GameObject stageBG2; //프로그레스 바의 배경 : 스테이지 2
    public GameObject stageBG3; //프로그레스 바의 배경 : 스테이지 3
    public Slider PrgsBar; //프로그레스 바 불러오기
    public TextMeshProUGUI timer; //진행도 표시(단위:km)
    public float prgs = 0; //실제 프로그레스 값(gTime)
    public float stagePrgs = 0; //프로그레스 바의 핸들이 다시 처음 위치로 돌아가기 위한 값
    public float stageCap1 = 10; //스테이지 1 클리어 위한 진행도
    public float stageCap2 = 20; //스테이지 2 클리어 위한 진행도
    public float stageCap3 = 30; //스테이지 3 클리어 위한 진행도

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        prgs = gameManager.gTime; 
        timer.text = $"{prgs:N0}" + "km"; //타이머에 표시될 진행도값(km)
        PrgsBar.value = prgs - stagePrgs; //스테이지가 전환된 진행도 만큼을 진행도에서 제거한 후 프로그레스 바에 표시

        if(prgs >= stageCap1) //스테이지 1 의 진행도를 만족(클리어)할 시
        {
            stageBG2.SetActive(true);
            stagePrgs = stageCap1;
        }
        if(prgs >= stageCap2) //스테이지 2의 진행도를 만족(클리어)할 시
        {
            stageBG3.SetActive(true);
            stagePrgs = stageCap2;
        }
    }
}