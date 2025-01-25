using Unity.Mathematics;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public GameObject Bubbles;
    public float BubbleLifeTime;
    public float LeftTime;
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
        LeftTime = BubbleLifeTime;
        if(Sprite == null){
            Sprite = GetComponent<SpriteRenderer>();
        }
        if(Audio == null){
            Audio = GetComponent<AudioSource>();
        }
        if(Bubbles == null || Bubbles.transform.childCount == 0){
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        LeftTime -= Time.deltaTime;
        if( LeftTime < 0 && Bubbles.transform.childCount != 0 ){
            Bubbles.transform.GetChild(0).GetComponent<BubbleStateController>().DestoryBubble();
            if(Bubbles.transform.childCount > 1){
                LeftTime = BubbleLifeTime;
            }
            else{
                //No more bubbles
                gameObject.SetActive(false);
                //gameover
            }
        }
        else{
            transform.position = Pos+Bubbles.transform.GetChild(0).position;
            if(LeftTime > (BubbleLifeTime*2)/3){
                //normal point
                float FlashSpeed = 8;
                if(Mathf.Sin(LeftTime*FlashSpeed)>0){
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
            else if(LeftTime > BubbleLifeTime/3){
                //faster point
                float FlashSpeed = 16;
                if(Mathf.Sin(LeftTime*FlashSpeed)>0){
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
                if(Mathf.Sin(LeftTime*FlashSpeed)>0){
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
}
