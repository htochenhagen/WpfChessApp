using System.Windows.Media;
using WpfChessApp.Models;

namespace WpfChessApp.Game;

/// <summary>
/// Spielfeld-Kachel/Feld
/// </summary>
public class BoardTile : GameObject
{
    public Brush Brush { get; set; } = Brushes.Red;
    public ChessToken? CurrentChessToken { get; set; } = null;
    public override string Name => "Chess Board Tile";
}