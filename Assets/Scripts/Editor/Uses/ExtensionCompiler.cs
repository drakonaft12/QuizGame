using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Compiles
{
    public class ExtensionCompiler : ICompileFactory
    {
        private readonly ICompileFactory _original;
        private readonly string _extension;

        public ExtensionCompiler(ICompileFactory original, string extension)
        {
            _original = original;
            _extension = extension;
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            if (Directory.Exists(path))
            {
                path = Path.ChangeExtension(path, _extension);
            }
            _original.Compile(path, buildOptions);
        }
    }
}
