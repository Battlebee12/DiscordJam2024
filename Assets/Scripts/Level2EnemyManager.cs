using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private BossHealth boss;
    
    public float spawnRadius = 10;
    public int maxEnimies = 7; 
    public float spawnFrequency = 1;
    public int currentEnimies =0;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTheEnimies",0.1f,spawnFrequency);

        
    }

    // Update is called once per frame
    void Update()

    {   
        currentEnimies = GameObject.FindGameObjectsWithTag("ENEMY").Length;
        if(boss.Health/boss.MaxHealth > 0.5f ){
            spawnFrequency = 1;
        }
        if(boss.Health/boss.MaxHealth > 0.25){
            spawnFrequency =2;
        }
        if(boss.Health/boss.MaxHealth > 0.05){
            spawnFrequency =4;
        }

    }
    private Vector3 GetRandomPointOnCircle(Vector3 center,float radius){

        // Generate a random angle in radians
        float randomAngle = Random.Range(0f, Mathf.PI * 2);

        // Calculate the x and y coordinates based on the angle and radius
        float x = center.x + radius * Mathf.Cos(randomAngle);
        float y = center.y + radius * Mathf.Sin(randomAngle);

        // Return the calculated point as a Vector2
        return new Vector3(x, y,0);

    }
    private void SpawnTheEnimies(){
        if(currentEnimies < maxEnimies){
            enemySpawner.SpawnEnemyLvl2(GetRandomPointOnCircle(playerTransform.position,spawnRadius));
        }
        
        currentEnimies++;

    }
}
