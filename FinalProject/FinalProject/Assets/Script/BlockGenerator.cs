using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    private float time;

    public GameObject Block1;
    public GameObject Block2;
    public GameObject Block3;


    private GameObject blockPrefab;

    private Vector3 spawnPos1;
    private Vector3 spawnPos2;
    private Vector3 spawnPos3;
    private Vector3 spawnPos4;
    private Vector3 spawnPos5;


    private float randomX1;
    private float randomX2;
    private float randomX3;
    private float randomX4;
    private float randomX5;



    private int blockIndex;

    void Start()
    {
        InvokeRepeating("BlockGen", 4, 1);          //시간마다 장애물 생성
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        time = gameManager.gTime;

        randomX1 = Random.Range(-4.0f, 4.0f);       //장애물 랜덤 좌표 받아오기
        randomX2 = Random.Range(-4.0f, 4.0f);
        randomX3 = Random.Range(-4.0f, 4.0f);
        randomX4 = Random.Range(-4.0f, 4.0f);
        randomX5 = Random.Range(-4.0f, 4.0f);
    }

    void BlockGen()
    {
        spawnPos1 = new Vector3(randomX1, 7.7f, -8.0f);         //랜덤 좌표 적용
        spawnPos2 = new Vector3(randomX2, 7.7f, -8.0f);
        spawnPos3 = new Vector3(randomX3, 7.7f, -8.0f);
        spawnPos4 = new Vector3(randomX4, 7.7f, -8.0f);
        spawnPos5 = new Vector3(randomX5, 7.7f, -8.0f);


        //시간별로 장애물 종류 바꿔주면서 인스턴스화
        if (time <= 60)
        {
            blockPrefab = Instantiate(Block1, spawnPos1, Quaternion.identity);
            blockPrefab = Instantiate(Block1, spawnPos2, Quaternion.identity);
            blockPrefab = Instantiate(Block1, spawnPos3, Quaternion.identity);
        }
        
        else if(time > 60 && time <= 120)
        {
            blockPrefab = Instantiate(Block2, spawnPos1, Quaternion.identity);
            blockPrefab = Instantiate(Block2, spawnPos2, Quaternion.identity);
            blockPrefab = Instantiate(Block2, spawnPos3, Quaternion.identity);
            blockPrefab = Instantiate(Block2, spawnPos4, Quaternion.identity);

        }

        else if(time > 120)
        {
            blockPrefab = Instantiate(Block3, spawnPos1, Quaternion.identity);
            blockPrefab = Instantiate(Block3, spawnPos2, Quaternion.identity);
            blockPrefab = Instantiate(Block3, spawnPos3, Quaternion.identity);
            blockPrefab = Instantiate(Block3, spawnPos4, Quaternion.identity);

        }
    }

}
