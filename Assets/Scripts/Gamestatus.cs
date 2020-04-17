using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamestatus : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled; //for autoplay

    //state variables
    [SerializeField] int currentScore = 0;

//Singleton Pattern    
    private void Awake(){
        int gameStatusCount = FindObjectsOfType<Gamestatus>().Length;
        if(gameStatusCount > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start(){
        scoreText.text = "Score: " + currentScore.ToString(); 
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(){
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = "Score: " + currentScore.ToString(); 
    }

    public void ResetGame(){
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }
}

