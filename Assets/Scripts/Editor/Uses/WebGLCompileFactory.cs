using UnityEditor;

namespace Compiles
{
    public class WebGLCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;

        public WebGLCompileFactory()
        {
            factory = new UsesCompileFactory(BuildTarget.WebGL);
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            PlayerSettings.WebGL.decompressionFallback = true;
            factory.Compile(path, buildOptions);
        }
    }

}