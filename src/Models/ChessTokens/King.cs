using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// König
/// </summary>
public class King : ChessToken
{
    public King(ChessTokenColor chessTokenColor)
    {
        ChessTokenColor = chessTokenColor; 
        ChessTokenNumber = ChessTokenNumber.Number1;
    }

    public override string Name => "King";

    public override MoveResult TryMove(Point oldPosition, Point newPosition)
    {
        return new MoveResult(false, "Not implemented at the moment!");
    }
}