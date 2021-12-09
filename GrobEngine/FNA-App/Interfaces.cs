using System;
using Microsoft.Xna.Framework;

namespace GrobEngine
{
    #region IObject
    public class IObject
    {
        public virtual void Initialize(GrobEngineMain game) { }
        public virtual void LoadContent(GrobEngineMain game) { }
        public virtual void UnloadContent(GrobEngineMain game) { }
        public virtual void Update(GrobEngineMain game, GameTime gameTime) { }
        public virtual void Draw(GrobEngineMain game, GameTime gameTime) { }
    }
    #endregion

    #region IEngine
    public class IEngine : IObject
    {
        public virtual void OnDeviceCreated(GrobEngineMain game, object sender, EventArgs e) { }
        public virtual void OnDeviceReset(GrobEngineMain game, object sender, EventArgs e) { }
    }
    #endregion
}
