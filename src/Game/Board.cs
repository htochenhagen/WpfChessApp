namespace WpfChessApp.Game;

/// <summary>
/// Spielfeld
/// </summary>
public class Board : GameObject
{
    public int Size = 8;

    public Board()
    {
        Tiles = new BoardTile[Size,Size];
    }

    public BoardTile[,] Tiles { get; }

    public override string Name => "Chess Board";
}