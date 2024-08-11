using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth :HealthEntity,IHasHealth
{
    public GameObject win;

    public void TookDamage(float damageAmount){
        Health = Health - damageAmount;
        Debug.Log("Took Damage, so Health remaning: " + Health);
        if(Health < 0){
            Died();
        }
        // call the health change event;
    }
    public void Heal(float HealAmount){
        Health = Health + HealAmount;
        if(Health > MaxHealth){
            Health = MaxHealth;
        }

        // call the health change event

    }
    public void Died(){
        win.SetActive(true);
        Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.CompareTag("PROJECTILE")){
            ProjectileSO projectileSO = other.gameObject.GetComponent<Projectiles>().GetProjectileSO();
            if(projectileSO != null){
                TookDamage(projectileSO.damage);
                Destroy(other.gameObject);
            }

        }
        
        
    }
    
}
