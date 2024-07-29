using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using View;

namespace View
{
    public class ReactFromFail : MonoBehaviour, IPointerClickHandler, IButtonEffect
    {
        [SerializeField] private bool use = true;
        private bool isCorrect = true;
        [SerializeField] private float amplitude = 1;
        [SerializeField] private float durationEffect = 0.9f;
        [SerializeField] private float durationPause = 0.3f;
        private Tween currentTween;
        private Vector3 clickPosition;

        private void Awake()
        {
            clickPosition = Vector3.right * amplitude;
        }

        public void Notify(bool correct)
        {
            isCorrect = correct;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!use || isCorrect)
            {
                return;
            }

            currentTween?.Kill();
            currentTween = DOTween.Sequence()
                           .AppendInterval(durationPause)
                           .Append(transform.DOPunchPosition(clickPosition, durationEffect,10,3));
        }
    }
}
