using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models;

/// <summary>
/// Spielfigur
/// </summary>
public abstract class ChessToken : GameObject
{
    public ChessTokenColor ChessTokenColor { get; set; }
    public ChessTokenNumber ChessTokenNumber { get; set; }
    public abstract MoveResult TryMove(Point oldPosition, Point newPosition);
}