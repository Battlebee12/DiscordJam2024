using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHasHealth
{
    public float Health = 100;
    public float MaxHealth = 100;

    public float invisTime = 2f;
    private bool invis = false;
    

    public void TookDamage(float damageAmount){
        if(!invis){
            Health = Health - damageAmount;
            Debug.Log("Player Took Damage, so Health remaning: " + Health);

            if(Health < 0){
                Died();
                return;
            }
            invis = true;

            Invoke("TurnOffInvis",invisTime);
  
        }
         
    }
    public void Heal(float healAmount){
        Health = Health + healAmount;
        if(Health > MaxHealth){
            Health = MaxHealth;
        }

    }
    public void Died(){
        // make it die.
        Destroy(gameObject);

    }
    private void TurnOffInvis(){
        invis = false;
    }
    private void OnCollisionEnter2D(Collision2D other) {

        Enemy enemy= other.gameObject.GetComponent<Enemy>( );
        if(enemy!=null){
            TookDamage(enemy.damaeAmount);
            // Temp fix of destroying the enemy if it collides with player. 
            //TODO: Call the future method that will dissolve the enemy in style.
            Destroy(other.gameObject);
        }
        
    }
    
}
