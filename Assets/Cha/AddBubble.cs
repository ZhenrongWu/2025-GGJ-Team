using UnityEngine;

public class AddBubble : MonoBehaviour
{
    public string Words = "Hello";
    public GameObject BubblePrefab;
    public Transform BubbleParent;
    public Transform BubbleSpawnPoint;
    void Start()
    {
        for(int i=0; i<10; i++){
            AddOneBubble(Words);
        }
    }

    // Update is called once per frame
    void AddOneBubble(string words){
        GameObject bubble = Instantiate(BubblePrefab, BubbleSpawnPoint.position, BubbleSpawnPoint.rotation, BubbleParent);
        bubble.GetComponentInChildren<TextMesh>().text = words;
    }
}
