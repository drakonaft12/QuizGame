using UnityEditor;

namespace Compiles
{
    public class APPCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;

        public APPCompileFactory()
        {
            factory = new UsesCompileFactory(BuildTarget.Android);
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            EditorUserBuildSettings.buildAppBundle = true;
            factory.Compile(path, buildOptions);
        }
    }

}