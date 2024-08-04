
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Compiles
{
    public class CompileFactory : MonoBehaviour
    {
        [MenuItem("CompileFactory/Compile1")]
        public static void Compile()
        {
            new ManyCompileFactory(
                    //new ExtensionCompiler(
                    //    new UsesCompileFactory(BuildTarget.StandaloneWindows64), 
                    //    ".exe"
                    //    ),
                    //new ExtensionCompiler(
                    //new APKCompileFactory(),".apk"
                    //),
                    //new ExtensionCompiler(
                    //new APPCompileFactory(), ".app"
                    //)
                    new ExtensionCompiler(
                    new WebGLCompileFactory(), ""
                    )

                    ).Compile(
                EditorUtility.OpenFolderPanel(
                    "Chouse folder", "Assets", "Build"
                    ), BuildOptions()
            );
        }

        public static BuildOptions BuildOptions()
        {
            return GetBuildPlayerOptions().options;
        }

        public static BuildPlayerOptions GetBuildPlayerOptions(BuildPlayerOptions defaultBuildPlayerOptions = new())
        {
            return BuildPlayerWindow.DefaultBuildMethods.GetBuildPlayerOptions(defaultBuildPlayerOptions);
        }
    }
}
