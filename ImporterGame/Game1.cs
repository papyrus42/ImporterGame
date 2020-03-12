using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ImportLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ImporterGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player balloon;
        List<Spikes> spikes = new List<Spikes>();
        AxisList world;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Stuff stuff = Content.Load<Stuff>("stuff");
            BoundaryRectangle bbr = new BoundaryRectangle(200, 400, 100, 50);
            balloon = new Player(this, bbr, 400);
            balloon.LoadContent(Content, "balloon");
            world = new AxisList();
            foreach (Vector2 v in stuff.points)
            {
                BoundaryRectangle sbr = new BoundaryRectangle(v, 20, 50);
                Spikes sp = new Spikes(sbr);
                sp.LoadContent(Content, "spike");
                spikes.Add(sp);
                world.AddGameObject(sp);
            }
            

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            balloon.Update(gameTime);
            var spikeQuery = world.QueryRange(balloon.bounds.X, balloon.bounds.X + balloon.bounds.Width);
            balloon.CheckForSpikeCollision(spikeQuery);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            var offset = new Vector2(200, 300) - balloon.Position;
            var t = Matrix.CreateTranslation(offset.X, offset.Y, 0);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, t);

            var spikeQuery = world.QueryRange(balloon.Position.X - 521, balloon.Position.X + 500);
            foreach (Spikes spike in spikeQuery)
            {
                spike.Draw(spriteBatch);
            }
            balloon.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
