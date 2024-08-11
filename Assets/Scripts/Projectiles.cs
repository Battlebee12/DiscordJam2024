using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
     [SerializeField] private ProjectileSO projectileSO;
     public ProjectileSO GetProjectileSO(){
        return projectileSO;
     }
     public void SetProjectileSO(ProjectileSO projectileSO){
        this.projectileSO = projectileSO;
     }
     private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
     }
    
}
