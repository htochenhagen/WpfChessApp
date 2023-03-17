using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Königin
/// </summary>
public class Queen : ChessToken
{
    public Queen(ChessTokenColor chessTokenColor)
    {
        ChessTokenColor = chessTokenColor;
        ChessTokenNumber = ChessTokenNumber.Number2;
    }

    public override string Name => "Queen";

    public override MoveResult TryMove(Point oldPosition, Point newPosition)
    {
        return new MoveResult(false, "Not implemented at the moment!");
    }
}