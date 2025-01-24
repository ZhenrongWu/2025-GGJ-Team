using Unity.Mathematics;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float BubbleLifeTime = 10f;
    [SerializeField]
    private float LeftTime;

    public GameObject Arrow;
    void Start()
    {
        LeftTime = BubbleLifeTime;
    }
    void Update()
    {
        LeftTime -= Time.deltaTime;
        //
        //sound change with timer;
        //phase 1 => .    .    .
        //phase 2 => .  .  .
        //phase 3 => . . .

        /// Shing Arrow
        if(LeftTime > (BubbleLifeTime*2)/3){
            if(Arrow != null){
                if(math.sin(LeftTime*8)>0){
                Arrow.SetActive(true);
                }
                else{
                    Arrow.SetActive(false);
                }
        }
            //play sound 1
        }
        else if(LeftTime > BubbleLifeTime/3){
            if(Arrow != null){
                if(math.sin(LeftTime*16)>0){
                Arrow.SetActive(true);
                }
                else{
                    Arrow.SetActive(false);
                }
            }
            //play sound 2
        }
        else{
            if(Arrow != null){
                if(math.sin(LeftTime*30)>0){
                Arrow.SetActive(true);
                }
                else{
                    Arrow.SetActive(false);
                }
            }
            //play sound 3
        }
        if(LeftTime <= 0){
            //Destroy the bubble
            Destroy(gameObject);
        }
    }
}
