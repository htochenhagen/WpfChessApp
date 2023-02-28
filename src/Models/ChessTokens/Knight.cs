using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Springer
/// </summary>
public class Knight : ChessToken
{
    public Knight(ChessTokenType chessTokenType)
    {
        ChessTokenType = chessTokenType;
    }

    public override string Name => "Knight";

    public override void Move(Point newPosition)
    {
        
    }
}