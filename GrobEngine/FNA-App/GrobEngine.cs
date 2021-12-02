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
        private IGame mainScript;
        public GraphicsDeviceManager graphics;
        #endregion

        #region Constructor
        private GrobEngineMain() : base()
        {
            //set the content root directory.
            Content.RootDirectory = "Data";

            //load main engine script.
            IGame tempLoader = ScriptEngine.LoadScriptFromContent("Engine/Scripts/EngineMain.cs", Content);

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
            mainScript.Initialize(this);
            base.Initialize();
        }

        private void OnDeviceCreated(object sender, EventArgs e)
        {
            mainScript.OnDeviceCreated(this, sender, e);
        }

        private void OnDeviceReset(object sender, EventArgs e)
        {
            mainScript.OnDeviceReset(this, sender, e);
        }

        protected override void LoadContent()
        {
            mainScript.LoadContent(this);
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            mainScript.UnloadContent(this);
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            mainScript.Update(this, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            mainScript.Draw(this, gameTime);
            base.Draw(gameTime);
        }
        #endregion
    }
    #endregion
}