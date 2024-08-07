using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Liderboards
{
    public class LocalLeaderboard : MonoBehaviour, ILiderboard
    {
        public async Task<IReadOnlyList<Record>> Leaders()
        {
            FileStream stream = new(Application.persistentDataPath + "/Leaderboard.json", FileMode.Open);

            StreamReader reader = new(stream);
            string json = await reader.ReadToEndAsync();
            reader.Close();
            stream.Close();
            json = "[" + json + "]";
            return JsonConvert.DeserializeObject<List<Record>>(json);
        }

        public async Task Note(string name, float time, int miss)
        {
            FileStream stream = new(Application.persistentDataPath + "/Leaderboard.json", FileMode.Append);

            StreamWriter writer = new(stream);

            Record record = new Record
            {
                Name = name,
                Time = time,
                Miss = miss
            };
            if (stream.Length != 0) await writer.WriteAsync(",\n");
            await writer.WriteAsync(JsonConvert.SerializeObject(record, Formatting.Indented));

            writer.Close();
            stream.Close();

        }
    }
}