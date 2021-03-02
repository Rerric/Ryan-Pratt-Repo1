using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void SpawnEnemy()
    {
        int randomenemy = Random.Range(1, 3);

        if (randomenemy == 1)
        {
            spawnPos = new Vector3(0, 0, 0);
            Instantiate(enemy1, transform.position, transform.rotation);
        }

        if (randomenemy == 2)
        {
            float offset = Random.Range(2, 7);
            spawnPos = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
            Instantiate(enemy2, spawnPos, transform.rotation);
        }
    }
}
