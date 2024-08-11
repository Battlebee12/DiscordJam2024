using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private Shoot_Projectile gun;
    [SerializeField] private Level1EnemyManager enemyManager;
    [SerializeField] private GameObject UpgradePanel1;
    [SerializeField] private GameObject UpgradePanel2;

    public int enemiesKilled = 0;
    private void Update() {
        if(enemiesKilled == 5){
            Upgrade1();
            

        }
    }
    private void Upgrade1(){


        gun.currentProjectile = Shoot_Projectile.ProjectileType.P2;
        enemyManager.maxEnimies += 10;
        enemyManager.spawnFrequency = 0.5f;
        enemyManager.spawnRadius = 5;
        UpgradePanel1.SetActive(true);
        pauseGame();
        
        StartCoroutine(ResumeAfterDelay(4f));
        enemiesKilled++;
    }

    private void pauseGame(){
        Time.timeScale = 0f;
    }

    private IEnumerator ResumeAfterDelay(float delay){
        yield return new WaitForSecondsRealtime(delay);
        resumeGame();
    }

    private void resumeGame(){
        Time.timeScale = 1f;
        UpgradePanel1.SetActive(false);  // Assuming you want to deactivate UpgradePanel1 instead of UpgradePanel2
        UpgradePanel2.SetActive(false);
    }
}
