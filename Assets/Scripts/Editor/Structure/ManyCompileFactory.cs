using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Compiles
{
    public class ManyCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory[] _factories;

        public ManyCompileFactory(params ICompileFactory[] factories)
        {
            _factories = factories;
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            foreach (var compileFactory in _factories)
            {
                compileFactory.Compile(path, buildOptions);
            }
        }
    }
}
