using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkles;
   // [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    Gamestatus score;

    //state variables
    [SerializeField] int timesHit; //TODO only serialized for debug purposes
    private void Start(){
        CountBreakableBlocks();
        score = FindObjectOfType<Gamestatus>();
    }

    private void CountBreakableBlocks(){
        level = FindObjectOfType<Level>();
        if(tag == "Breakable" ){
        level.CountBlocks();
        }
    }
    private void OnCollisionEnter2D (Collision2D collision){
        if(tag == "Breakable"){
          HandleHit();
        }
   }

   private void HandleHit(){
         timesHit++;
         int maxHits = hitSprites.Length +1; //add after  the serialized
            if(timesHit >= maxHits){
                DestroyBlock();
            }
            else{
                ShowNextHitSprite();
            }
   }

   private void ShowNextHitSprite(){
       int spriteIndex = timesHit - 1;
       GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
       /* if(hitSprites[spriteIndex] != null){
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else{
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        } */
   }

   private void DestroyBlock(){
       score.AddToScore();
       AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
       Destroy(gameObject);
       level.BlockDestroyed();
       TriggerSparklesVFX();
   }

   private void TriggerSparklesVFX(){
       GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
   }

}
