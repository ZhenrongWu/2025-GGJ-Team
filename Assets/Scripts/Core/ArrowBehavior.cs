using Unity.Mathematics;
using UnityEngine;
using Core;
public class ArrowBehavior : MonoBehaviour
{
    
    [HideInInspector]
    public float BubbleLifeTime = 5;
    public float Counter;
    [SerializeField]
    private AudioClip ClickSound;
    [SerializeField]
    private AudioSource Audio;
    [SerializeField]
    private SpriteRenderer Sprite;
    bool IsPlaying = false;
    BubbleController _BubbleController;
    void Start()
    {
        Counter = 0;
    }
    void Update()
    {
        Counter += Time.deltaTime;
        Flash();
    }

    void Flash(){
        if(Counter < BubbleLifeTime/3 ){
            //normal point
            float FlashSpeed = 8;
            if(Mathf.Sin(Counter*FlashSpeed)>0){
                Sprite.enabled = true;
                if(!IsPlaying){
                    Audio.PlayOneShot(ClickSound);
                    IsPlaying = true;
                }
            }
            else{
                Sprite.enabled = false;
                IsPlaying = false;
                Debug.Log("Flash");
            }
        }
        else if(Counter < BubbleLifeTime * 2 / 3){
            //faster point
            float FlashSpeed = 16;
            if(Mathf.Sin(Counter*FlashSpeed)>0){
                Sprite.enabled = true;
                if(!IsPlaying){
                    Audio.PlayOneShot(ClickSound);
                    IsPlaying = true;
                }
            }
            else{
                Sprite.enabled = false;
                IsPlaying = false;
            }
                
        }
        else if(Counter < BubbleLifeTime){
            //urgent point
            float FlashSpeed = 30;
            if(Mathf.Sin(Counter*FlashSpeed)>0){
                Sprite.enabled = true;
                if(!IsPlaying){
                    Audio.PlayOneShot(ClickSound);
                    IsPlaying = true;
                }
            }
            else{
                Sprite.enabled = false;
                IsPlaying = false;
            }
        }
    }
}
