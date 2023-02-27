using System;
using System.Diagnostics;
using System.Windows;

namespace WpfChessApp.Game;

public class Game
{
    private Board _board;
    public Size Resolution { get; set; }

    public void Load()
    {
        Debug.WriteLine("Load game");
        var boardBuilder = new BoardBuilder();
        _board = boardBuilder.Build();
   }

    public void Update(TimeSpan gameTime)
    {
        Debug.WriteLine("Update game");
    }

    public void Draw()
    {
        Debug.WriteLine("Draw game");
    }

    public void Unload()
    {
        Debug.WriteLine("Unload game");
    }
}