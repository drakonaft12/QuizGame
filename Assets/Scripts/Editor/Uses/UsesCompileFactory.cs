using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Compiles
{
    public class UsesCompileFactory : ICompileFactory
    {
        private readonly BuildTarget _buildTarget;

        public UsesCompileFactory(BuildTarget buildTarget)
        {
            _buildTarget = buildTarget;
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            BuildPipeline.BuildPlayer(Scenes(), path, _buildTarget, buildOptions);
        }

        private static EditorBuildSettingsScene[] Scenes()
        {
            return EditorBuildSettings.scenes;
        }
    }
}
