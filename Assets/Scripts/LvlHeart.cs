using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlHeart : HealthEntity, IHasHealth
{
    [SerializeField] private GameObject nextLevel;


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
        nextLevel.SetActive(true);
        Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D other) {
        // TODO: ignore anything other than projectile.
        if(other.gameObject.CompareTag("PROJECTILE")){
            ProjectileSO projectileSO = other.gameObject.GetComponent<Projectiles>().GetProjectileSO();
            if(projectileSO != null){
                TookDamage(projectileSO.damage);
                Destroy(other.gameObject);
            }

        }
        
        
    }
}
