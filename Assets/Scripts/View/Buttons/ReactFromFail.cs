using DG.Tweening;
using UnityEngine;

namespace View
{
    public class ReactFromFail : MonoBehaviour, IButtonEffect
    {
        [SerializeField] private bool use = true;
        private Tween currentTween;
        [SerializeField] private float amplitude = 1;
        [SerializeField] private float durationEffect = 0.9f;
        [SerializeField] private float durationPause = 0.3f;
        private Vector3 clickPosition;
        private Vector3 defaultPosition;

        private void Awake()
        {
            clickPosition = Vector3.right * amplitude;
        }

        private void OnDisable()
        {
            currentTween.Kill(true);
            defaultPosition = Vector3.zero;
        }

        public void Notify(bool correct)
        {

            if (!use || correct)
            {
                return;
            }

            defaultPosition = defaultPosition == Vector3.zero ? transform.position: defaultPosition;

            transform.DOKill();
            currentTween = DOTween.Sequence()
            .Append(transform.DOMove(defaultPosition,durationPause))
            .Append(transform.DOPunchPosition(clickPosition, durationEffect, 10, 3));
        }

    }
}
