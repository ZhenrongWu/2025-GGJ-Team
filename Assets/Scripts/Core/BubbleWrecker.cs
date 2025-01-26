using UnityEngine;

namespace Core
{
    public class BubbleWrecker : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Bubble")) return;

            for (var i = 0; i < other.transform.parent.childCount; i++)
                other.transform.parent.GetChild(i).GetComponent<BubbleState>().TriggerCrackEffect();
        }
    }
}