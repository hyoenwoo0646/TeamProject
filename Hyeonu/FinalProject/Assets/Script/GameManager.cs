using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = false; //게임이 "실행중"인지 확인하는 변수
    public GameObject settings; //일시정지 메뉴 불러오기(ESC 버튼으로 활/비활성화)
    public float gTime;

    void Start()
    {
        isPlaying = true; //게임 매니저가 시작할 때 "실행중"으로 변경
    }

    void Update()
    {
        if(isPlaying == true) //게임이 실행중일 때 진행될 요소
        {
            gTime += Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            stopGame();
        }
    }

    public void stopGame() //외부에서 Message()로 호출하며, isPlaying의 값에 따라 게임 정지/재시작
    {
        if(isPlaying == true)
        {
            Time.timeScale = 0;
            settings.SetActive(true);
            isPlaying = false;
            return;
        }
        else
        {
            Time.timeScale = 1;
            settings.SetActive(false);
            isPlaying = true;
            return;
        }
    }
}