using System.Net.Sockets;
using System.Windows.Media;
using WpfChessApp.Models.ChessTokens;

namespace WpfChessApp.Game;

/// <summary>
/// Spielfeld-Erbauer
/// </summary>
public class BoardBuilder
{
    public Board Build()
    {
        var board = new Board();
        for (var rowIndex = 1; rowIndex <= board.Size; rowIndex++)
        {
            for (var columnIndex = 1; columnIndex <= board.Size; columnIndex++)
            {
                var boardTile = new BoardTile { Brush = Brushes.Wheat };
                if ((rowIndex % 2 == 0 && columnIndex % 2 != 0) || (rowIndex % 2 != 0 && columnIndex % 2 == 0))
                    boardTile.Brush = Brushes.Peru;
                if (rowIndex == 1)
                {
                    boardTile.CurrentChessToken = columnIndex switch
                    {
                        1 => new Rook(ChessTokenType.White),
                        2 => new Knight(ChessTokenType.White),
                        3 => new Bishop(ChessTokenType.White),
                        4 => new King(ChessTokenType.White),
                        5 => new Queen(ChessTokenType.White),
                        6 => new Bishop(ChessTokenType.White),
                        7 => new Knight(ChessTokenType.White),
                        8 => new Rook(ChessTokenType.White),
                        _ => boardTile.CurrentChessToken
                    };
                }
                if (rowIndex == 2)
                {
                    boardTile.CurrentChessToken = new Pawn(ChessTokenType.White);
                }
                if (rowIndex == 7)
                {
                    boardTile.CurrentChessToken = new Pawn(ChessTokenType.Black);
                }
                if (rowIndex == 8)
                {
                    boardTile.CurrentChessToken = columnIndex switch
                    {
                        1 => new Rook(ChessTokenType.Black),
                        2 => new Knight(ChessTokenType.Black),
                        3 => new Bishop(ChessTokenType.Black),
                        4 => new King(ChessTokenType.Black),
                        5 => new Queen(ChessTokenType.Black),
                        6 => new Bishop(ChessTokenType.Black),
                        7 => new Knight(ChessTokenType.Black),
                        8 => new Rook(ChessTokenType.Black),
                        _ => boardTile.CurrentChessToken
                    };
                }


                board.Tiles[rowIndex - 1, columnIndex - 1] = boardTile;
            }
        }

        return board;
    }
}