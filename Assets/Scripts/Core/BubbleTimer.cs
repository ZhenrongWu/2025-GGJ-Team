using UnityEngine;

namespace Core
{
    public class BubbleTimer : MonoBehaviour
    {
        [Range(1, 5)] [SerializeField] private int        count    = 1;
        [SerializeField]               private float      lifeTime = 1;
        [SerializeField]               private GameObject prefab;

        private float _counter;

        public int BubbleCount
        {
            get => count;
            set => count = value;
        }

        public float Counter => _counter;

        private void Update()
        {
            _counter += Time.deltaTime;
            if (_counter >= lifeTime)
            {
                count--;
                transform.GetChild(0).GetComponent<BubbleState>().TriggerCrackEffect();

                _counter = 0;
            }
        }
    }
}