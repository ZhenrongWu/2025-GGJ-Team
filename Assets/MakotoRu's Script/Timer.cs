using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float BubbleLifeTime = 10f;
    // Update is called once per frame
    void Update()
    {
        //
        //sound change with timer;
        //phase 1 => .    .    .
        //phase 2 => .  .  .
        //phase 3 => . . .
        //
        BubbleLifeTime -= Time.deltaTime;
        if(BubbleLifeTime <= 0)
        {
            //Destroy the bubble
        }
    }
}
