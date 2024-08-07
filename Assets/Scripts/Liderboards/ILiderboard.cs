using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Liderboards
{
    public interface ILiderboard
    {
        public Task Note(string name, float time, int miss);
        public Task<IReadOnlyList<Record>> Leaders();
    }

    public class Record
    {
        public string Name { get; set; }
        public float Time { get; set; }
        public int Miss { get; set; }
    }
}
