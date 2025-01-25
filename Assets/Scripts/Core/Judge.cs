using UnityEngine;

public class Judge : MonoBehaviour
{
    [SerializeField]private SpriteRenderer SpriteRenderer;
    [SerializeField]private Sprite Sprite1;

    [SerializeField]private Sprite Sprite2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Bubble")
        {
            for(int i = 0; i < other.transform.parent.childCount; i++){
                other.transform.parent.GetChild(i).GetComponent<BubbleStateController>().DestoryBubble();
            }



            ///judege 
            SpriteRenderer.sprite = Sprite1;
        }
    }
}