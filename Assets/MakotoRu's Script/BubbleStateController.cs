using UnityEngine;

public class BubbleStateController : MonoBehaviour
{
    public Animator BubbleAnimator;
    public AudioSource PopSound;
    public void DestoryBubble(){
        if(PopSound != null){
            PopSound.Play();
        }
        if(BubbleAnimator != null){
            BubbleAnimator.SetTrigger("pop");
            Debug.Log("pop!");
            Destroy(gameObject, 0.35f);
        }
        else{
            Destroy(gameObject);
        }
    }
}
