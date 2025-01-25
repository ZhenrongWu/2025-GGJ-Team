using Core;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class AddBubble : MonoBehaviour
{
    public string Words = "Hello";
    public float AnimationTime;
    public float SpriteWidth;
    public GameObject BubblePrefab;
    float Counter;
    public GameObject Character;

    public bool IsFinish;
    GameObject CurrBubble;
    [SerializeField]
    int Index;
    void Start()
    {
        IsFinish = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Index = 0;
        CurrBubble = AddOneBubble(Words, Index);
        Counter = 0;
        gameObject.GetComponent<BubbleController>().bubbleCount = Words.Length;
        if(Character == null){
            Character = GameObject.Find("Character1");
        }
    }

    void Update(){
        Counter += Time.deltaTime;
        if(CurrBubble!=null){
            //CurrBubble.transform.localScale = Vector3.one * Counter / AnimationTime;
        }
        if(Counter >= AnimationTime && Index < Words.Length){
            //CurrBubble.transform.localScale = Vector3.one;
            Counter = 0;
            Index++;
            CurrBubble = AddOneBubble(Words, Index);
        }
        if(Index >= Words.Length || CurrBubble == null){
            //CurrBubble = null;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            if(Character != null){
                Character.GetComponent<Animator>().SetTrigger("AddFinish");
            }
            IsFinish = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    GameObject AddOneBubble(string words,int index){
        Vector3 position;
        if(index >= Words.Length){
            return null;
        }
        if(index == 0){
            position = new Vector3(transform.position.x + SpriteWidth * index, transform.position.y,transform.position.z);
        } else{
            position = new Vector3(CurrBubble.transform.position.x - SpriteWidth, transform.position.y,transform.position.z);
        }
        GameObject bubble = Instantiate(BubblePrefab, position, transform.rotation, gameObject.transform);
        TextMeshPro _textMesh = bubble.transform.GetChild(0).GetComponentInChildren<TextMeshPro>();
        if(_textMesh != null&& index < Words.Length){
            _textMesh.text = Words[index] + "";
        }
        Tween tween = bubble.transform.DOScale(Vector3.one, AnimationTime).SetEase(Ease.InOutBounce);
        bubble.transform.localScale = Vector3.zero;
        return bubble;
    }
}
