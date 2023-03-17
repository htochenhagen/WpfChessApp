using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Turm
/// </summary>
public class Rook : ChessToken
{
    public Rook(ChessTokenColor chessTokenColor, ChessTokenNumber chessTokenNumber)
    {
        ChessTokenColor = chessTokenColor;
        ChessTokenNumber = chessTokenNumber;
    }

    public override string Name => "Rook";

    public override MoveResult TryMove(Point oldPosition, Point newPosition)
    {
        return new MoveResult(false, "Not implemented at the moment!");
    }
}