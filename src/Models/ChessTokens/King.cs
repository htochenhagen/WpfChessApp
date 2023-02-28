using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// König
/// </summary>
public class King : ChessToken
{
    public King(ChessTokenType chessTokenType)
    {
        ChessTokenType = chessTokenType;
    }

    public override string Name => "King";

    public override void Move(Point newPosition)
    {

    }
}