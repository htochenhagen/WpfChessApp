using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Läufer
/// </summary>
public class Bishop : ChessToken
{
    public Bishop(ChessTokenColor chessTokenColor, ChessTokenNumber chessTokenNumber)
    {
        ChessTokenColor = chessTokenColor;
        ChessTokenNumber = chessTokenNumber;
    }

    public override string Name => "Bishop";

    public override MoveResult TryMove(Point oldPosition, Point newPosition)
    {
        return new MoveResult(false, "Not implemented at the moment!");
    }
}