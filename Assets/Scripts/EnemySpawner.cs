using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyListSO enemyListSO;
    
    private GameObject[] enemyList1;
    private GameObject[] enemyList2;
    private GameObject[] enemyList3;
    // Start is called before the first frame update
    void Start()
    {
        enemyList1 = enemyListSO.level1Enimies;
        enemyList2 = enemyListSO.level2Enimies;
        enemyList3 = enemyListSO.level3Enimies;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemyLvl1(Vector3 position){
        //TODO: Make it spawn mroe based on intensity

        int index = UnityEngine.Random.Range(0,enemyList1.Length);

        Instantiate(enemyList1[index],position,Quaternion.identity);

    }
}
