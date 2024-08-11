using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private GameObject settings;
   public void PlayGame(){
    SceneManager.LoadScene("FIRST");
   }
   public void ExitGame(){
    Application.Quit();
   }
   public void Setting(){
    settings.SetActive(true);
   }
}
