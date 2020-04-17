using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour

{
    [SerializeField] float minP = 1f;
    [SerializeField] float maxP = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    //cached references
    Gamestatus theGameStatus;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameStatus = FindObjectOfType<Gamestatus>();
        theBall =  FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(),minP,maxP);
        transform.position = paddlePos;
    }

    //for Autoplay
    private float GetXPos(){
        if(theGameStatus.IsAutoPlayEnabled()){
            return theBall.transform.position.x;
        }
        else{
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
