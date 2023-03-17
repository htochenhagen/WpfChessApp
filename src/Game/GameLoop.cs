using System.Threading.Tasks;
using System;
using System.Windows.Controls.Primitives;

namespace WpfChessApp.Game;

public class GameLoop
{
    private Game? _myGame;

    /// <summary>
    /// Status of GameLoop
    /// </summary>
    public bool Running { get; private set; }

    /// <summary>
    /// Load Game into GameLoop
    /// </summary>
    public void Load(Game gameObj)
    {
        _myGame = gameObj;
    }

    public async void UpdateGame(GameContext gameContext)
    {
        _myGame?.Update(gameContext);
    }

    /// <summary>
        /// Start GameLoop
        /// </summary>
    public async void Start()
    {
        if (_myGame == null)
            throw new ArgumentException("Game not loaded!");

        // Load game content
        _myGame.Load();

        // Set game loop state
        Running = true;

        // Set previous game time
        var previousGameTime = DateTime.Now;

        while (Running)
        {
            // Calculate the time elapsed since the last game loop cycle
            var gameTime = DateTime.Now - previousGameTime;
            // Update the current previous game time
            previousGameTime = previousGameTime + gameTime;
            // Update the game
            //_myGame.Update(gameTime);
            // Update Game at 60fps
            await Task.Delay(8);
        }
    }

    /// <summary>
    /// Stop GameLoop
    /// </summary>
    public void Stop()
    {
        Running = false;
        _myGame?.Unload();
    }

    /// <summary>
    /// Draw Game Graphics
    /// </summary>
    /// <param name="uniformGrid"></param>
    public void Draw(UniformGrid uniformGrid)
    {
        _myGame?.Draw(uniformGrid);
    }
}