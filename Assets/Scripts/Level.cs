using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakanleBlocks;

    //cached reference
    SceneLoader sceneLoader;

    private void Start(){
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void CountBlocks()
    {
        breakanleBlocks++;
    }

    public void BlockDestroyed(){
       breakanleBlocks--;
       if(breakanleBlocks <= 0){
           sceneLoader.LoadNexteScene();
       }
    }
}
