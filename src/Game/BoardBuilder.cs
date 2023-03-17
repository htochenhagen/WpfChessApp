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
                        1 => new Rook(ChessTokenColor.White, ChessTokenNumber.Number1),
                        2 => new Knight(ChessTokenColor.White, ChessTokenNumber.Number1),
                        3 => new Bishop(ChessTokenColor.White, ChessTokenNumber.Number1),
                        4 => new King(ChessTokenColor.White),
                        5 => new Queen(ChessTokenColor.White),
                        6 => new Bishop(ChessTokenColor.White, ChessTokenNumber.Number2),
                        7 => new Knight(ChessTokenColor.White, ChessTokenNumber.Number2),
                        8 => new Rook(ChessTokenColor.White, ChessTokenNumber.Number2),
                        _ => boardTile.CurrentChessToken
                    };
                }
                if (rowIndex == 2)
                {
                    boardTile.CurrentChessToken = new Pawn(ChessTokenColor.White, (ChessTokenNumber) columnIndex);
                }
                if (rowIndex == 7)
                {
                    boardTile.CurrentChessToken = new Pawn(ChessTokenColor.Black, (ChessTokenNumber)columnIndex);
                }
                if (rowIndex == 8)
                {
                    boardTile.CurrentChessToken = columnIndex switch
                    {
                        1 => new Rook(ChessTokenColor.Black, ChessTokenNumber.Number1),
                        2 => new Knight(ChessTokenColor.Black, ChessTokenNumber.Number1),
                        3 => new Bishop(ChessTokenColor.Black, ChessTokenNumber.Number1),
                        4 => new King(ChessTokenColor.Black),
                        5 => new Queen(ChessTokenColor.Black),
                        6 => new Bishop(ChessTokenColor.Black, ChessTokenNumber.Number2),
                        7 => new Knight(ChessTokenColor.Black, ChessTokenNumber.Number2),
                        8 => new Rook(ChessTokenColor.Black, ChessTokenNumber.Number2),
                        _ => boardTile.CurrentChessToken
                    };
                }


                board.Tiles[rowIndex - 1, columnIndex - 1] = boardTile;
            }
        }

        return board;
    }
}