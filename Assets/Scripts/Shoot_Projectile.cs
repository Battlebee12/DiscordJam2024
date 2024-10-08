using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot_Projectile : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
     private ProjectileSO projectileSO;
    [SerializeField] private ProjectileListSO projectileListSO;
    public enum ProjectileType{
        P1,
        P2,
        P3
    }
    public ProjectileType currentProjectile;
    public float shootFrequency = 2;
    public float bulletsPerShot = 5;
    private void Start() {
        InvokeRepeating("ShootWithDelay",0.01f, shootFrequency);
        
    }
    

    private void Update() {
        switch (currentProjectile){
            case ProjectileType.P1:
                projectileSO = projectileListSO.projectileSOList[0];
                break;
            case ProjectileType.P2:
                projectileSO = projectileListSO.projectileSOList[1];
                break;
            case ProjectileType.P3:
                projectileSO = projectileListSO.projectileSOList[2];
                break;    
        }

        //Invoke("ShootMultipleTimes", shootFrequency);
    }
   public void Shoot(Transform startPoint, ProjectileSO projectileSO)
    {
        // Get the mouse position in the world
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // Ensure z-coordinate is 0 for 2D games

        // Calculate the direction from the start point to the mouse position
        Vector3 direction = (mousePosition - startPoint.position).normalized;


        // Instantiate the projectile using the ScriptableObject data
        GameObject projectile = Instantiate(projectileSO.prefab, startPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Set the velocity of the projectile
        rb.velocity = direction * projectileSO.speed;

        // Set the projectile's lifetime
        Destroy(projectile, projectileSO.lifetime);
    }
    IEnumerator ShootMultipleTimes()
    {
        for (int i = 0; i < bulletsPerShot; i++)
        {
           Shoot(startPoint,projectileSO); // Call the Shoot method
            yield return new WaitForSeconds(0.2f); // Wait for 0.5 seconds before the next shot
        }
    }
    private void ShootWithDelay(){
        StartCoroutine(ShootMultipleTimes());
    }



}
