using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Compiles
{
    public interface ICompileFactory
    {
        public void Compile(string path, BuildOptions buildOptions);
    }
}
