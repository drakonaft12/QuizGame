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

        [ContextMenu("Show")]
        public async void Show()
        {
            var records = await localLeaderboard.Leaders();
            string t = "";
            foreach (var record in records)
            {
                t += $"\n{record.Name} \t| {record.Time} \t| {record.Miss}";
            }
            Debug.Log(t);
        }
    }
}
