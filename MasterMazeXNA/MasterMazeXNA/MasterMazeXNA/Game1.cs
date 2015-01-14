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

namespace MasterMazeXNA
{
	 /// <summary>
	 /// This is the main type for your game
	 /// </summary>
	 public class Game1: Microsoft.Xna.Framework.Game
	 {
		  //Constants
		  private const int mWidth = 50;
		  private const int mHeight = 50;

		  //Graphic related constants
		  private const int blockSize = 10;
		  private const int blockBuffer = blockSize + 2;
		  private const int edgeBuffer = 5;
		  private const int screenHeight = blockBuffer * mWidth + edgeBuffer*2;
		  private const int screenWidth = blockBuffer * mHeight + edgeBuffer*2;

		  //basic variables
		  private int[,] board = new int[mWidth, mHeight];

		  //2D textures
		  private Texture2D wallSpace;
		  private Texture2D uncheckedSpace;
		  private Texture2D delvedSpace;
		  private Texture2D currentSpace;

		  GraphicsDeviceManager graphics;
		  SpriteBatch spriteBatch;

		  public Game1()
		  {
				//Don't erase this
				graphics = new GraphicsDeviceManager(this);

				//Set graphics settings
				graphics.IsFullScreen = false;
				graphics.PreferredBackBufferHeight = screenHeight;
				graphics.PreferredBackBufferWidth = screenWidth;

				//Don't erase this
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


				//Don't erase this
				base.Initialize();
		  }

		  /// <summary>
		  /// LoadContent will be called once per game and is the place to load
		  /// all of your content.
		  /// </summary>
		  protected override void LoadContent()
		  {

				// Create a new SpriteBatch, which can be used to draw textures.
				spriteBatch = new SpriteBatch(GraphicsDevice);//Don't erase this

				//Set content
				wallSpace = Content.Load<Texture2D>("wallSpace");
				uncheckedSpace = Content.Load<Texture2D>("uncheckedSpace");
				delvedSpace = Content.Load<Texture2D>("delvedSpace");
				currentSpace = Content.Load<Texture2D>("currentSpace");
				// TODO: use this.Content to load your game content here
		  }

		  /// <summary>
		  /// UnloadContent will be called once per game and is the place to unload
		  /// all content.
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
				// Allows the game to exit
				if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
					 this.Exit();

				// TODO: Add your update logic here

				base.Update(gameTime);
		  }

		  /// <summary>
		  /// This is called when the game should draw itself.
		  /// </summary>
		  /// <param name="gameTime">Provides a snapshot of timing values.</param>
		  protected override void Draw(GameTime gameTime)
		  {
				GraphicsDevice.Clear(Color.Gray);

				spriteBatch.Begin();
				
				for(int y = 0; y < mHeight; y++)
				{
					 for(int x = 0; x < mWidth; x++)
					 {
						  spriteBatch.Draw(wallSpace, new Rectangle(blockBuffer * x + edgeBuffer, blockBuffer * y + edgeBuffer, blockSize, blockSize), Color.White);
					 }
				}

				spriteBatch.End();

				base.Draw(gameTime);
		  }
	 }
}