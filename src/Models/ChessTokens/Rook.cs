using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Turm
/// </summary>
public class Rook : ChessToken
{
    public Rook(ChessTokenType chessTokenType)
    {
        ChessTokenType = chessTokenType;
    }

    public override string Name => "Rook";

    public override void Move(Point newPosition)
    {
        
    }
}