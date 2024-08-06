using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Liderboards
{
    public class LiderboardView : MonoBehaviour
    {
        //[SerializeField] private NetworkLeaderboard networkLeaderboard;
        [SerializeField] private LocalLeaderboard localLeaderboard;

        public async void Show()
        {
            //Debug.Log(JsonConvert.SerializeObject(await));
        }
    }
}
