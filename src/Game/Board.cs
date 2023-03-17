using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WpfChessApp.Models;

namespace WpfChessApp.Game;

/// <summary>
/// Spielfeld
/// </summary>
public class Board : GameObject
{
    public int Size = 8;

    public Board()
    {
        Tiles = new BoardTile[Size,Size];
    }

    public BoardTile[,] Tiles { get; }

    public override string Name => "Chess Board";

    public IDictionary<Guid, Point> ChessTokensPositions
    {
        get
        {
            var chessTokensPositions = new Dictionary<Guid, Point>();
            for (var rowIndex = 1; rowIndex <= Size; rowIndex++)
            {
                for (var columnIndex = 1; columnIndex <= Size; columnIndex++)
                {
                    var boardTile = Tiles[rowIndex - 1, columnIndex - 1];
                    if (boardTile.CurrentChessToken == null) continue;

                    chessTokensPositions.Add(boardTile.CurrentChessToken.Id, new Point(rowIndex - 1, columnIndex - 1));
                }
            }
            return chessTokensPositions;
        }
    }

    public IDictionary<Guid, ChessToken> ChessTokens
    {
        get
        {
            var chessTokens = new Dictionary<Guid, ChessToken>();
            foreach (var boardTile in Tiles)
            {
                if (boardTile.CurrentChessToken == null) continue;
                chessTokens.Add(boardTile.CurrentChessToken.Id, boardTile.CurrentChessToken);
            }
            return chessTokens;
        }
    }

    public bool TryGetChessToken(string chessTokenName, ChessTokenColor chessTokenColor,
        ChessTokenNumber chessTokenNumber, out ChessToken? chessToken)
    {
        chessToken = ChessTokens.Values.FirstOrDefault(ct => ct.Name == chessTokenName && ct.ChessTokenColor == chessTokenColor && ct.ChessTokenNumber == chessTokenNumber);
        return chessToken != null;
    }
}