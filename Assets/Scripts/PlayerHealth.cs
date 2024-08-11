using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : HealthEntity, IHasHealth
{
    public GameObject gameOverScreen;
    

    public float invisTime = 2f;
    private bool invis = false;
    [SerializeField] private PlayerVisuals animations;
    

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
        animations.TookHit();
         
    }
    public void Heal(float healAmount){
        Health = Health + healAmount;
        if(Health > MaxHealth){
            Health = MaxHealth;
        }

    }
    public void Died(){
        // make it die
        gameOverScreen.SetActive(true);

        Destroy(gameObject);


    }
    private void TurnOffInvis(){
        invis = false;
    }
    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("ENEMY")){
            Enemy enemy= other.gameObject.GetComponent<Enemy>( );
            if(enemy!=null){
                TookDamage(enemy.damaeAmount);
                // Temp fix of destroying the enemy if it collides with player. 
                //TODO: Call the future method that will dissolve the enemy in style.
                Destroy(other.gameObject);
            }

        }
        if(other.gameObject.CompareTag("BOSS")){
            TookDamage(30);

        }

        
        
    }
    
}
