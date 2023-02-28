using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Bauer
/// </summary>
public class Pawn : ChessToken
{
    public Pawn(ChessTokenType chessTokenType)
    {
        ChessTokenType = chessTokenType;
    }

    public override string Name => "Pawn";

    public override void Move(Point newPosition)
    {
        
    }
}