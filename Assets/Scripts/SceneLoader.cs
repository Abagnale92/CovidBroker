using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNexteScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFirsteScene(){
        
        SceneManager.LoadScene(0);
        FindObjectOfType<Gamestatus>().ResetGame();
    }

    
    public void Quit(){
        
        Application.Quit();
    }
}
