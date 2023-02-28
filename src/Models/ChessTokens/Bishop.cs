using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Läufer
/// </summary>
public class Bishop : ChessToken
{
    public Bishop(ChessTokenType chessTokenType)
    {
        ChessTokenType = chessTokenType;
    }

    public override string Name => "Bishop";

    public override void Move(Point newPosition)
    {
        
    }
}