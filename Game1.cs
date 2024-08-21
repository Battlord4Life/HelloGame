using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace HelloGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _ballTexture;
        private Vector2 _ballPos;
        private Vector2 _ballVel;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _ballPos = new((_graphics.GraphicsDevice.Viewport.Width-50) / 2, (_graphics.GraphicsDevice.Viewport.Height -50) / 2);
            // TODO: Add your initialization logic here
            System.Random rand = new();
            _ballVel = new((float)rand.NextDouble(), (float)rand.NextDouble());
            _ballVel.Normalize();
            _ballVel *= 250;
            Window.AllowUserResizing = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _ballTexture = Content.Load<Texture2D>("GameBall");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _ballPos += _ballVel * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_ballPos.X < _graphics.GraphicsDevice.Viewport.X || _ballPos.X > _graphics.GraphicsDevice.Viewport.Width - 100) _ballVel.X *= -1;
            if (_ballPos.Y < _graphics.GraphicsDevice.Viewport.Y || _ballPos.Y > _graphics.GraphicsDevice.Viewport.Height - 100) _ballVel.Y *= -1;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.RosyBrown);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            _spriteBatch.Draw(_ballTexture, _ballPos, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
