using Unity.Mathematics;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public GameObject CurrentBubble;
    public float BubbleLifeTime;
    public float LeftTime;
    public Vector3 Pos;
    [SerializeField]
    private AudioClip ClickSound;
    [SerializeField]
    private AudioSource audioSource;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        LeftTime = BubbleLifeTime;
        if(spriteRenderer == null){
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if(audioSource == null){
            audioSource = GetComponent<AudioSource>();
        }

    }
    bool IsPlaying = false;
    void Update()
    {
        LeftTime -= Time.deltaTime;
        if(LeftTime<0&&CurrentBubble!=null){
            GameObject Temp = CurrentBubble.GetComponent<BubbleStateController>().NextBubble;
            CurrentBubble.GetComponent<BubbleStateController>().DestoryBubble();
            if(Temp!=null){
                LeftTime = BubbleLifeTime;
                CurrentBubble = Temp;
            }
            else{//end of the chain
                Destroy(gameObject);
                //gameover
            }
        }
        else{
            transform.position = Pos+CurrentBubble.transform.position;
            if(LeftTime > (BubbleLifeTime*2)/3){
                if(math.sin((LeftTime-(BubbleLifeTime*2)/3)*8)>0){
                    spriteRenderer.enabled = true;
                    if(!IsPlaying){
                        audioSource.PlayOneShot(ClickSound);
                        IsPlaying = true;
                    }
                }
                else{
                    spriteRenderer.enabled = false;
                    IsPlaying = false;
                }
            }
            else if(LeftTime > BubbleLifeTime/3){
                if(math.sin((LeftTime-(BubbleLifeTime*2)/3)*16)>0){
                    spriteRenderer.enabled = true;
                    if(!IsPlaying){
                        audioSource.PlayOneShot(ClickSound);
                        IsPlaying = true;
                    }
                }
                else{
                    spriteRenderer.enabled = false;
                    IsPlaying = false;
                }
                    
            }
            else{
                if(math.sin(LeftTime*30)>0){
                    spriteRenderer.enabled = true;
                    if(!IsPlaying){
                        audioSource.PlayOneShot(ClickSound);
                        IsPlaying = true;
                    }
                }
                else{
                    spriteRenderer.enabled = false;
                    IsPlaying = false;
                }
            }
        }
    }
}
