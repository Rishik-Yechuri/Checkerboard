using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Checkerboard
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int GRID_SIZE = 8;
        Texture2D red, black;
        String[,] strgrid;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 100 * GRID_SIZE;
            graphics.PreferredBackBufferHeight = 100 * GRID_SIZE;

            graphics.ApplyChanges();
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            strgrid = new String[GRID_SIZE, GRID_SIZE];
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    if (x % 2 == 0)
                    {
                        if (y % 2 == 0)
                            strgrid[x, y] = "r";
                        else if (y % 2 == 1)
                            strgrid[x, y] = "b";
                    }
                    else if (x % 2 == 1)
                    {
                        if (y % 2 == 0)
                            strgrid[x, y] = "b";
                        else if (y % 2 == 1)
                            strgrid[x, y] = "r";
                    }
                }
            }

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            red = this.Content.Load<Texture2D>("Red Square Checkers");
            black = this.Content.Load<Texture2D>("Black Square Checkers");
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { this.Exit();}
            // TODO: Add your update logic here
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            for (int xPos = 0; xPos < GRID_SIZE; xPos++)
            {
                for (int yPos = 0; yPos < GRID_SIZE; yPos++)
                {
                    if (strgrid[xPos, yPos].Equals("r"))
                    {
                        spriteBatch.Draw(red, new Rectangle(xPos * 100, yPos * 100, 100, 100), Color.White);
                    }
                    else if (strgrid[xPos, yPos].Equals("b"))
                    {
                        spriteBatch.Draw(black, new Rectangle(xPos * 100, yPos * 100, 100, 100), Color.White);
                    }
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}