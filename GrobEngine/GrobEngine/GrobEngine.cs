﻿#region Usings
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

            //enable high DPI
            Environment.SetEnvironmentVariable("FNA_GRAPHICS_ENABLE_HIGHDPI", "1");

            //load main engine script.
            IEngine tempLoader = (IEngine)Script.LoadScriptFromContent("Engine/Scripts/EngineMain.cs", Content);

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
                Script.ErrorHandler("Initialize(): " + ex.Message, true);
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
                Script.ErrorHandler("OnDeviceCreated(): " + ex.Message, true);
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
                Script.ErrorHandler("OnDeviceReset(): " + ex.Message, true);
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
                Script.ErrorHandler("LoadContent(): " + ex.Message, true);
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
                Script.ErrorHandler("UnloadContent(): " + ex.Message, true);
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
                Script.ErrorHandler("Update(): " + ex.Message, true);
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
                Script.ErrorHandler("Draw(): " + ex.Message, true);
            }
        }
        #endregion
    }
    #endregion
}