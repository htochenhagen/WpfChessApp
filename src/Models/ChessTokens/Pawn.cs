using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Bauer
/// </summary>
public class Pawn : ChessToken
{
    public Pawn(ChessTokenColor chessTokenColor, ChessTokenNumber chessTokenNumber)
    {
        ChessTokenColor = chessTokenColor;
        ChessTokenNumber = chessTokenNumber;
    }

    public override string Name => "Pawn";

    public override MoveResult TryMove(Point oldPosition, Point newPosition)
    {
        // TODO: implement correct logic here and return appropriate move result!
        return new MoveResult(true);
    }
}