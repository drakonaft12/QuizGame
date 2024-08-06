using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Liderboards
{
    public class StopWatch
    {
        private float _startTime;

        public void Start()
        {
            _startTime = Time.time;
        }
        public float Stop()
        {
            var elapsedTime = Time.time - _startTime;
            _startTime = 0;
            return elapsedTime;
        }
    }
}