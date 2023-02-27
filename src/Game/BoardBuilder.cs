using System.Windows.Media;

namespace WpfChessApp.Game;

/// <summary>
/// Spielfeld-Erbauer
/// </summary>
public class BoardBuilder
{
    public Board Build()
    {
        var board = new Board();
        for (var i = 0; i < board.Size; i++)
        {
            for (var j = 0; j < board.Size; j++)
            {
                var boardTile = new BoardTile { Brush = Brushes.Wheat };
                if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                    boardTile.Brush = Brushes.Black;
                board.Tiles[i, j] = boardTile;
            }
        }
        return board;
    }
}