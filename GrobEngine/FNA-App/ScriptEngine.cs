#region Usings
using System;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Linq;
#endregion

// based on https://stackoverflow.com/questions/137933/what-is-the-best-scripting-language-to-embed-in-a-c-sharp-desktop-application
namespace GrobEngine
{
    #region IGame
    public interface IGame
    {
        void Initialize(GrobEngineMain game);
        void OnDeviceCreated(GrobEngineMain game, object sender, EventArgs e);
        void OnDeviceReset(GrobEngineMain game, object sender, EventArgs e);
        void LoadContent(GrobEngineMain game);
        void UnloadContent(GrobEngineMain game);
        void Update(GrobEngineMain game, GameTime gameTime);
        void Draw(GrobEngineMain game, GameTime gameTime);
     }
    #endregion

    #region ScriptEngine
    public class ScriptEngine
    {
        public static IGame LoadScriptFromContent(string scriptpath, ContentManager content)
        {
            string fullScriptPath = content.RootDirectory + '/' + scriptpath;

            try
            {
                using (var stream = TitleContainer.OpenStream(fullScriptPath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string script = reader.ReadToEnd();
                        Assembly compiled = CompileScript(script, fullScriptPath);
                        IGame code = ExecuteScript(compiled);
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler(fullScriptPath + ": " + ex.Message, true);
            }

            return null;
        }

        private static IGame ExecuteScript(Assembly assemblyScript)
        {
            if (assemblyScript == null)
            {
                goto error;
            }

            foreach (Type type in assemblyScript.GetExportedTypes())
            {
                foreach (Type intface in type.GetInterfaces())
                {
                    if (intface == typeof(IGame))
                    {
                        ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);

                        if (constructor != null && constructor.IsPublic)
                        {
                            IGame finalScript = constructor.Invoke(null) as IGame;
                            return finalScript;
                        }
                        else
                        {
                            ErrorHandler("Constructor does not exist or it is not public.", true);
                            return null;
                        }
                    }
                }
            }

error:
            ErrorHandler("Failed to load script.", true);
            return null;
        }

        private static Assembly CompileScript(string code, string filePath)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();

            CompilerParameters perams = new CompilerParameters();
            perams.GenerateExecutable = false;
            perams.GenerateInMemory = true;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).Select(a => a.Location);
            perams.ReferencedAssemblies.AddRange(assemblies.ToArray());

            CompilerResults result = provider.CompileAssemblyFromSource(perams, code);

            foreach (CompilerError error in result.Errors)
            {
                ErrorHandler(error, filePath, error.IsWarning, false);
            }

            if (result.Errors.HasErrors)
            {
                return null;
            }

            return result.CompiledAssembly;
        }

        private static void ErrorHandler(string error, bool finalError)
        {
            ErrorHandler(error, false, finalError);
        }

        private static void ErrorHandler(string error, bool warning, bool finalError)
        {
            Console.WriteLine(warning ? "[WARNING] - " : "[ERROR] - " 
                + error);
            PauseAndExit(finalError);
        }

        private static void ErrorHandler(CompilerError error, string fileName, bool warning, bool finalError)
        {
            Console.WriteLine(warning ? "[WARNING] - " : "[ERROR] - " +
                fileName + " (" + error.Line + "," + error.Column + "): " 
                + error.ErrorText);
            PauseAndExit(finalError);
        }

        private static void PauseAndExit(bool pause)
        {
            if (pause)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }
    #endregion
}
