using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Liderboards.View
{
    public class SubmitLeaderView : MonoBehaviour
    {
        public readonly UnityEvent SubmitEvent = new();
        [SerializeField] private TMP_Text timeText;
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private Button submitButton;
        [SerializeField] private float recordsTime;
        private ILiderboard liderboard;
        private readonly StopWatch stopWatch = new();

        private void Awake()
        {
            liderboard = GetComponent<ILiderboard>();

        }
        private void Start()
        {
            submitButton.onClick.AddListener(Submit);
        }

        private async void Submit()
        {
            await liderboard.Note(nameInput.text, recordsTime);
            SubmitEvent.Invoke();
        }

        public void StartAndHide()
        {
            stopWatch.Start();
            transform.localScale = Vector3.zero;
        }

        public void Stop()
        {
            recordsTime = stopWatch.Stop();
            transform.localScale = Vector3.one;
            timeText.text = "Scored: " + recordsTime.ToString("0.00");

        }
    }
}
