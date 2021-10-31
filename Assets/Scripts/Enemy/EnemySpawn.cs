using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] TimeManager TimeManager;
    [SerializeField] GameManager GameManager;
    public GameObject enemy;
    public float spawnTime = 1f;
    public float rateTime = 3;
    public Transform[] spawnPoints;
    void Start()
    {
        // Repeat void spawn
        InvokeRepeating("Spawn", spawnTime, rateTime);
    }
    private void Update()
    {
        if (TimeManager.endTime <= 3)
        {
            CancelInvoke();
        }
        if (TimeManager.endTime <= 0)
        {
            GameManager.GameOver(true);
        }
    }
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation).GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100);
    }
    
}