using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelItemGenerator : MonoBehaviour
{
    GameManager gameManager;
    public float time;

    public GameObject Block;

    private GameObject blockPrefab;

    private Vector3 spawnPos1;
    private Vector3 spawnPos2;
    private Vector3 spawnPos3;

    private float randomX1;
    private float randomX2;
    private float randomX3;

    private int blockIndex;

    void Start()
    {
        InvokeRepeating("BlockGen", 7, 20);
    }

    void Update()
    {
        randomX1 = Random.Range(-4.0f, 4.0f);
        randomX2 = Random.Range(-4.0f, 4.0f);
        randomX3 = Random.Range(-4.0f, 4.0f);
    }

    void BlockGen()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        time = gameManager.gTime;

        spawnPos1 = new Vector3(randomX1, 7.7f, -8.0f);
        spawnPos2 = new Vector3(randomX2, 7.7f, -8.0f);
        spawnPos3 = new Vector3(randomX3, 7.7f, -8.0f);

        blockPrefab = Instantiate(Block, spawnPos1, Quaternion.identity);
            
    }
}
