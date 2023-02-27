using System.Windows.Media;

namespace WpfChessApp.Game;

/// <summary>
/// Spielfeld-Kachel/Feld
/// </summary>
public class BoardTile : GameObject
{
    public Brush Brush { get; set; } = Brushes.Wheat;
    public override string Name => "Chess Board Tile";
}