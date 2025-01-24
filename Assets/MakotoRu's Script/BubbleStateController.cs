using UnityEngine;

public class BubbleStateController : MonoBehaviour
{
    public Animator animator;
    public GameObject NextBubble;
    public AudioSource PopSound;
    public void DestoryBubble(){
        if(PopSound != null){
            PopSound.Play();
        }
        if(animator != null){
            animator.SetTrigger("pop");
            Debug.Log("pop!");
            Destroy(gameObject, 0.35f);
        }
        else{
            Destroy(gameObject);
        }
    }
}
