using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
[SerializeField] private GameObject[] Enemy;// add SerializeField - Encapsulation
[SerializeField] private  GameObject[] PowerUp;// add SerializeField - Encapsulation
[SerializeField] private GameObject player;// add SerializeField - Encapsulation

    private float EnemySpawnZ = 11.0f;
    private float EnemySpawnRangeX = 11.0f;
    private float EnemySpawnY = 0.55f;
    private float powerUpSpawnZ = 2.0f;

    [SerializeField] private float powerUpSpawnTime = 10.0f;// add SerializeField - Encapsulation

    private float enemySpawnTime = 2.0f;
    private float startDelay = 1.5f;
    private float PlayerSpawnZ = -2;
    private float PlayerSpawnY = 0.2f;
    private float PlayerSpawnX = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("RandomEnemySpown", startDelay, enemySpawnTime);
        InvokeRepeating("RandomSpawnPowerUp", startDelay, powerUpSpawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Method for spawn Enemy
    void RandomEnemySpown()// abstraction
    {
       float randomX = Random.Range(-EnemySpawnRangeX, EnemySpawnRangeX);
       int randomIndex = Random.Range(0, Enemy.Length);
       Vector3 spawnPos = new Vector3(randomX, EnemySpawnY, EnemySpawnZ);

       Instantiate(Enemy[randomIndex], spawnPos, Enemy[randomIndex].gameObject.transform.rotation);

    }

    // Method for spawn PowerUp
    void RandomSpawnPowerUp() // abstraction
    {
        float randomX = Random.Range(-EnemySpawnRangeX, EnemySpawnRangeX);
        float randomZ = Random.Range(-powerUpSpawnZ, powerUpSpawnZ);
        int randomIndex = Random.Range(0, PowerUp.Length);
        Vector3 spawnPos = new Vector3(randomX, EnemySpawnY, randomZ);
        Instantiate(PowerUp[randomIndex], spawnPos, PowerUp[randomIndex].gameObject.transform.rotation);
   
    }

    

   

}
