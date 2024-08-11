using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Animator animator;

    private void Update() {
        //Moving right
        if(playerController.MovementDirection == 1){
            animator.SetBool("RIGHT",true);
        }
        //moving left
        if(playerController.MovementDirection == -1){
            animator.SetBool("RIGHT",true);
            
        }
        if(playerController.MovementDirectionVertical == 1){
            animator.SetBool("UP",true); 
        }
        if(playerController.MovementDirectionVertical == -1){
            animator.SetBool("UP",false); 
        }

    }

    public void TookHit(){
        animator.SetBool("HIT",true);
        StartCoroutine(HitBack());
    }
    IEnumerator  HitBack(){
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("HIT", false);

    }

}
