using System;
using Microsoft.Xna.Framework;

namespace GrobEngine
{
    #region IGame
    public interface IObject
    {
        void Initialize(GrobEngineMain game);
        void LoadContent(GrobEngineMain game);
        void UnloadContent(GrobEngineMain game);
        void Update(GrobEngineMain game, GameTime gameTime);
        void Draw(GrobEngineMain game, GameTime gameTime);
    }
    #endregion

    #region IEngine
    public interface IEngine : IObject
    {
        void OnDeviceCreated(GrobEngineMain game, object sender, EventArgs e);
        void OnDeviceReset(GrobEngineMain game, object sender, EventArgs e);
    }
    #endregion
}
