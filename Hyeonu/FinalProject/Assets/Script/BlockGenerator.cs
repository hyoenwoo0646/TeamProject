using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] Block;

    private GameObject blockPrefab;

    private Vector3 spawnPos;

    private float randomX;

    private int blockIndex;

    void Start()
    {
        InvokeRepeating("BlockGen", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        randomX = Random.Range(-4.0f, 4.0f);
        Debug.Log(randomX);
    }

    void BlockGen()
    {
        spawnPos = new Vector3(randomX , 7.7f, -7.619018f);

        blockIndex = Random.Range(0, 5);
        blockPrefab = Instantiate(Block[blockIndex], spawnPos, Quaternion.identity);
    }

}
