using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHasHealth
{
    public float Health = 100;
    public float MaxHealth = 100;

    public float damaeAmount = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        Health = 100f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
