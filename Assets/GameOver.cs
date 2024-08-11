using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void MainMenu(){
        SceneManager.LoadScene("MAINMENU");
    }
}
