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
            throw new System.NotImplementedException();
        }

        public async Task Note(string name, float time)
        {
            FileStream stream = new(Application.persistentDataPath + "/Leaderboard.json", FileMode.Append);
            
            StreamWriter writer = new(stream);

            Record record = new Record
            {
                Name = name,
                Time = time
            };
            if(stream.Length != 0) await writer.WriteAsync(",\n");
            await writer.WriteAsync(JsonConvert.SerializeObject(record, Formatting.Indented));

            writer.Close();
            stream.Close();
            
        }

        private  void Save(IReadOnlyList<Record> records)
        {
            FileStream stream = new FileStream(Application.persistentDataPath + "/Leaderboard.json", FileMode.Create);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(JsonConvert.SerializeObject(records));
            writer.Close();
            stream.Close();
        }
    }
}