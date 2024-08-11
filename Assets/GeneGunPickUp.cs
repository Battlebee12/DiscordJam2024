using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneGunPickUp : MonoBehaviour
{
    public GameObject geneGun;

    private void OnPickup(){
        geneGun.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("PLAYER")){
            OnPickup();
            Destroy(gameObject);
        }

    }
}
