using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCasters : MonoBehaviour
{
    [SerializeField] GameObject[] Pre_Enemies;
    [SerializeField] float SpawnInterval;
    Transform Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("SpawnEnemy", 2, SpawnInterval);
    }

    
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        GameObject temp = Instantiate(Pre_Enemies[Random.Range(0, Pre_Enemies.Length)], transform.position + new Vector3(0, 0, Random.Range(-20, 20)), Quaternion.identity);
        temp.transform.LookAt(Player.position);
    }
}
