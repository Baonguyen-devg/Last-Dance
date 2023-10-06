using RepeatUtil.DesignPattern.SingletonPattern;
using UnityEngine;

namespace DefaultNamespace
{
    public class HeadPositionChecker : Singleton<HeadPositionChecker>
    {
        [SerializeField] private Transform headPlayerOne;
        [SerializeField] private Transform headPlayerTwo;
        [SerializeField] private float coordinateYWarning = -2.5f;

        public Transform IsHeadOneWarning()
        {
            if (headPlayerOne.localPosition.y <= coordinateYWarning)
                return headPlayerOne;
            return null;
        }
        
        public Transform IsHeadTwoWarning()
        {
            if (headPlayerTwo.localPosition.y <= coordinateYWarning)
                return headPlayerTwo;
            return null;
        }
        
        protected override void RemoveDuplicates()
        {
            if(instance != null) { Destroy(gameObject); return; }
            instance = this;
        }
    }
}