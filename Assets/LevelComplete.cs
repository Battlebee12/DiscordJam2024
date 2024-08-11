using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public bool bossFight = false;
    public void NextLevel(){
        if(!bossFight){
            SceneManager.LoadScene("BOSSFIGHT");
        }
        if(bossFight){
            SceneManager.LoadScene("WIN");
        }
        
    }
    public void MainMenu(){
        SceneManager.LoadScene("MAINMENU");
    }
}
