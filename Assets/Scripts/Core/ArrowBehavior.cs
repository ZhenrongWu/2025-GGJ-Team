using Unity.Mathematics;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public GameObject Target;
    public float BubbleLifeTime;
    public float Counter;
    public Vector3 Pos;
    [SerializeField]
    private AudioClip ClickSound;
    [SerializeField]
    private AudioSource Audio;
    [SerializeField]
    private SpriteRenderer Sprite;
    bool IsPlaying = false;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    /*void Flash(float time){
        if(time > (BubbleLifeTime*2)/3){
            //normal point
            float FlashSpeed = 8;
            if(Mathf.Sin(time*FlashSpeed)>0){
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
        else if(time > BubbleLifeTime/3){
            //faster point
            float FlashSpeed = 16;
            if(Mathf.Sin(counter*FlashSpeed)>0){
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
        else{
            //urgent point
            float FlashSpeed = 30;
            if(Mathf.Sin(time*FlashSpeed)>0){
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
    }*/
}
