using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
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
        [SerializeField] private int _miss;
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
            await liderboard.Note(nameInput.text, recordsTime, _miss);
            SubmitEvent.Invoke();
            transform.localScale = Vector3.zero;
            await Task.Delay(500);
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        public void StartAndHide()
        {
            stopWatch.Start();
            transform.localScale = Vector3.zero;
        }

        public void Stop(int miss = 0)
        {
            recordsTime = stopWatch.Stop();
            _miss = miss;
            transform.localScale = Vector3.one;
            timeText.text = $"Scored: {recordsTime.ToString("0.00")} Miss: {miss}";

        }
    }
}
