#region Usings
using Microsoft.Xna.Framework;
using System;
#endregion

namespace GrobEngine
{
    #region GrobEngineMain
    public class GrobEngineMain : Game
    {
        #region Main Loop
        static void Main(string[] args)
        {
            // begin engine loop
            using (GrobEngineMain g = new GrobEngineMain())
            {
                g.Run();
            }
        }
        #endregion

        #region Private Variables
        //the main engine script.
        private IEngine mainScript;
        public GraphicsDeviceManager graphics;
        #endregion

        #region Constructor
        private GrobEngineMain() : base()
        {
            //set the content root directory.
            Content.RootDirectory = "Data";

            //load main engine script.
            IEngine tempLoader = (IEngine)ScriptEngine.LoadScriptFromContent("Engine/Scripts/EngineMain.cs", Content);

            if (tempLoader != null)
            {
                mainScript = tempLoader;
            }

            graphics = new GraphicsDeviceManager(this);
            graphics.DeviceCreated += OnDeviceCreated;
            graphics.DeviceReset += OnDeviceReset;
        }
        #endregion

        #region Functions
        protected override void Initialize()
        {
            try
            {
                mainScript.Initialize(this);
                base.Initialize();
            }
            catch (Exception ex)
            {
                ScriptEngine.ErrorHandler("Initialize(): " + ex.Message, true);
            }
        }

        private void OnDeviceCreated(object sender, EventArgs e)
        {
            try
            {
                mainScript.OnDeviceCreated(this, sender, e);
            }
            catch (Exception ex)
            {
                ScriptEngine.ErrorHandler("OnDeviceCreated(): " + ex.Message, true);
            }
        }

        private void OnDeviceReset(object sender, EventArgs e)
        {
            try
            {
                mainScript.OnDeviceReset(this, sender, e);
            }
            catch (Exception ex)
            {
                ScriptEngine.ErrorHandler("OnDeviceReset(): " + ex.Message, true);
            }
        }

        protected override void LoadContent()
        {
            try
            {
                mainScript.LoadContent(this);
                base.LoadContent();
            }
            catch (Exception ex)
            {
                ScriptEngine.ErrorHandler("LoadContent(): " + ex.Message, true);
            }
        }

        protected override void UnloadContent()
        {
            try
            {
                mainScript.UnloadContent(this);
                base.UnloadContent();
            }
            catch (Exception ex)
            {
                ScriptEngine.ErrorHandler("UnloadContent(): " + ex.Message, true);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            try
            {
                mainScript.Update(this, gameTime);
                base.Update(gameTime);
            }
            catch (Exception ex)
            {
                ScriptEngine.ErrorHandler("Update(): " + ex.Message, true);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            try
            {
                mainScript.Draw(this, gameTime);
                base.Draw(gameTime);
            }
            catch (Exception ex)
            {
                ScriptEngine.ErrorHandler("Draw(): " + ex.Message, true);
            }
        }
        #endregion
    }
    #endregion
}