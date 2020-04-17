using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f, yPush = 12f;

    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    Vector2 paddleToBallVector;

    private bool hasStarted = false;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D, startmyRigidbody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        startmyRigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if(!hasStarted){
        LockBallToPaddle();
        LaunchOnMouseClick();
        }

    }

    private void LaunchOnMouseClick(){
        if(Input.GetMouseButtonDown(0)){
            myRigidbody2D.velocity = new Vector2(xPush,yPush);
            hasStarted = true;
        }

    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    /* private void OnCollisionEnter2D(Collision2D collision){
        if(hasStarted){
        GetComponent<AudioSource>().Play();
        }
    } Only one audio */

private void OnCollisionEnter2D(Collision2D collision){
    Vector2 velocityTweak = new Vector2
        (Random.Range(0.1f, randomFactor),
        Random.Range(0.1f, randomFactor));
    
    if(hasStarted){
        AudioClip clip = ballSounds[Random.Range(0,ballSounds.Length)];
        myAudioSource.PlayOneShot(clip);
        myRigidbody2D.velocity += velocityTweak;
        }

    }

}
