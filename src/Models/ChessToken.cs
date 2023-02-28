using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models;

/// <summary>
/// Spielfigur
/// </summary>
public abstract class ChessToken : GameObject
{
    public Point CurrentPosition { get; set; }
    public ChessTokenType ChessTokenType { get; set; }
    public abstract void Move(Point newPosition);
}