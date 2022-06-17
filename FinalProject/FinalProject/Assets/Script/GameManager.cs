using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = false; //게임이 "실행중"인지 확인하는 변수
    public bool isOver = true; //게임이 "종료"되었는지 확인하는 변수
    public GameObject settings; //일시정지 메뉴 불러오기(ESC 버튼으로 활/비활성화)
    public GameObject gameOverWindow;
    public float gTime;
    public GameObject player;
    public TextMeshProUGUI score;

    void Start() //게임 매니저가 시작할 때 "실행중"으로 변경
    {
        Time.timeScale = 1;
        isPlaying = true; 
        isOver = false;
    }

    void Update()
    {
        if(isOver == false){ //게임이 종료되지 않았다면
            if(isPlaying == true) //게임이 실행중일 때 진행될 요소
            {
                gTime += Time.deltaTime;
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                stopGame();
            }
        }
    }

    public void stopGame() //외부에서 stopGame()으로 호출하며, isPlaying의 값에 따라 게임 일시정지/재개
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

    public void endGame()//체력 0 됐을때 아예 끝나게 하는 함수
    {
        if(isPlaying == true)
        {
            Time.timeScale = 0;
            isPlaying = false;
        }
        return;
    }

    public void gameOver() //게임(한 판)이 온전히 종료
    {
        isOver = true;
        gameOverWindow.SetActive(true);
        score.text = $"{gTime:N1}";
    }

    public void scene_begin() //초기화면으로
    {
        stopGame();
        SceneManager.LoadScene("Begin");
    }
    
    public void scene_restart() //Main 씬 재시작
    {
        SceneManager.LoadScene("Main");
    }

    public void scene_quit() //어플리케이션 종료. #if는 에디터상에서도 종료시키기 위함
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}