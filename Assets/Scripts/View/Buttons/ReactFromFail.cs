using DG.Tweening;
using UnityEngine;

namespace View
{
    public class ReactFromFail : MonoBehaviour, IButtonEffect
    {
        [SerializeField] private bool use = true;
        [SerializeField] private float amplitude = 1;
        [SerializeField] private float durationEffect = 0.9f;
        [SerializeField] private float durationPause = 0.3f;
        private Vector3 clickPosition;

        private void Awake()
        {
            clickPosition = Vector3.right * amplitude;
        }

        public void Notify(bool correct)
        {
            if (!use || correct)
            {
                return;
            }
            
            transform.DOKill();
            DOTween.Sequence()
            .AppendInterval(durationPause)
            .Append(transform.DOPunchPosition(clickPosition, durationEffect, 10, 3));
        }

    }
}
