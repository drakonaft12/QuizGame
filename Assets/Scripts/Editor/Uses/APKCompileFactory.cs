using UnityEditor;

namespace Compiles
{
    public class APKCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;

        public APKCompileFactory()
        {
            factory = new UsesCompileFactory(BuildTarget.Android);
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            EditorUserBuildSettings.buildAppBundle = false;
            factory.Compile(path, buildOptions);
        }
    }

}