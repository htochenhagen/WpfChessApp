using System.Drawing;
using WpfChessApp.Game;

namespace WpfChessApp.Models.ChessTokens;

/// <summary>
/// Königin
/// </summary>
public class Queen : ChessToken
{
    public Queen(ChessTokenType chessTokenType)
    {
        ChessTokenType = chessTokenType;
    }

    public override string Name => "Queen";

    public override void Move(Point newPosition)
    {
        
    }
}