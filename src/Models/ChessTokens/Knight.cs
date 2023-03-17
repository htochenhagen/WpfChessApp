using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Springer
/// </summary>
public class Knight : ChessToken
{
    public Knight(ChessTokenColor chessTokenColor, ChessTokenNumber chessTokenNumber)
    {
        ChessTokenColor = chessTokenColor;
        ChessTokenNumber = chessTokenNumber;
    }

    public override string Name => "Knight";

    public override MoveResult TryMove(Point oldPosition, Point newPosition)
    {
        return new MoveResult(false, "Not implemented at the moment!");
    }
}