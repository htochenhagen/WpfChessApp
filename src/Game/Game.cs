using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfChessApp.Models;

namespace WpfChessApp.Game;

public class Game
{
    private Board? _board;
    private readonly Dictionary<string, ImageSource> _images = new();

    public Size Resolution { get; set; }

    public void Load()
    {
        Debug.WriteLine("Load game");
        var boardBuilder = new BoardBuilder();
        _board = boardBuilder.Build();
        
        _images.Add("Pawn_White", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Pawn_White.png")));
        _images.Add("Pawn_Black", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Pawn_Black.png")));
        _images.Add("Rook_White", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Rook_White.png")));
        _images.Add("Rook_Black", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Rook_Black.png")));
        _images.Add("Knight_White", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Knight_White.png")));
        _images.Add("Knight_Black", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Knight_Black.png")));
        _images.Add("Bishop_White", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Bishop_White.png")));
        _images.Add("Bishop_Black", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Bishop_Black.png")));
        _images.Add("King_White", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/King_White.png")));
        _images.Add("King_Black", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/King_Black.png")));
        _images.Add("Queen_White", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Queen_White.png")));
        _images.Add("Queen_Black", CreateBitmapImage(new Uri("pack://application:,,,/Game/ChessTokens/Queen_Black.png")));
    }

    public void Update(GameContext gameContext)
    {
        if (string.IsNullOrWhiteSpace(gameContext.CurrentChessToken)) return;
            
        var currentChessToken = MapChessToken(gameContext);
        if (currentChessToken == null) return;
        var newPosition = MapPosition(gameContext.NewPosition);
        var oldPosition = _board!.ChessTokensPositions[currentChessToken.Id];
        
        var moveResult = currentChessToken.TryMove(oldPosition, newPosition);
        if (!moveResult.Success)
        {
            // TODO: The MessageBox should not be here!
            // The fail message must be passed on so that the UI can display it.
            // Maybe you can solve this via events!
            MessageBox.Show(moveResult.FailMessage);
            return;
        }

        _board.Tiles[oldPosition.X, oldPosition.Y].CurrentChessToken = null;
        _board.Tiles[newPosition.X, newPosition.Y].CurrentChessToken = currentChessToken;
    }

    private ChessToken? MapChessToken(GameContext gameContext)
    {
        ChessTokenNumber chessTokenNumber;
        var chessTokenNumberAsString = string.Empty;
        if (gameContext.CurrentChessToken.StartsWith("Left"))
        {
            chessTokenNumber = ChessTokenNumber.Number1;
        }
        else if(gameContext.CurrentChessToken.StartsWith("Right"))
        {
            chessTokenNumber = ChessTokenNumber.Number2;
        }
        else
        {
            chessTokenNumberAsString = Regex.Split(gameContext.CurrentChessToken, @"\D+").LastOrDefault() ?? "0";
            chessTokenNumber = (ChessTokenNumber)int.Parse(chessTokenNumberAsString);
        }

        var chessTokenName = gameContext.CurrentChessToken.Replace("Left", "").Replace("Right", "")
            .Replace(chessTokenNumberAsString, "");

        if (_board!.TryGetChessToken(chessTokenName, gameContext.CurrentPlayer, chessTokenNumber, out var chessToken))
        {
            return chessToken;
        }

        return null;
    }

    private System.Drawing.Point MapPosition(string newPosition)
    {
        var rowLetter = newPosition[0].ToString();
        var column = int.Parse(newPosition[1].ToString()) - 1;
        switch (rowLetter)
        {
            case "A":
                return new System.Drawing.Point(0, column);
            case "B":
                return new System.Drawing.Point(1, column);
            case "C":
                return new System.Drawing.Point(2, column);
            case "D":
                return new System.Drawing.Point(3, column);
            case "E":
                return new System.Drawing.Point(4, column);
            case "F":
                return new System.Drawing.Point(5, column);
            case "G":
                return new System.Drawing.Point(6, column);
            case "H":
                return new System.Drawing.Point(7, column);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Draw(UniformGrid uniformGrid)
    {
        Debug.WriteLine("Draw game");

        uniformGrid.Children.Clear();

        for (var row = 0; row < 10; row++)
        {
            for (var column = 0; column < 10; column++)
            {
                if (column == 0 || column == 9)
                {
                    string label;
                    switch (row)
                    {
                        case 1:
                            label = "A";
                            break;
                        case 2:
                            label = "B";
                            break;
                        case 3:
                            label = "C";
                            break;
                        case 4:
                            label = "D";
                            break;
                        case 5:
                            label = "E";
                            break;
                        case 6:
                            label = "F";
                            break;
                        case 7:
                            label = "G";
                            break;
                        case 8:
                            label = "H";
                            break;
                        default:
                            AddEmptyTile(uniformGrid);

                            continue;
                    }

                    var textBlock = new TextBlock()
                    {
                        Text = label,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 36,
                        FontWeight = FontWeights.UltraBold
                    };

                    uniformGrid.Children.Add(textBlock);

                    continue;
                }

                if (row == 0 || row == 9)
                {
                    var label = column.ToString();

                    var textBlock = new TextBlock()
                    {
                        Text = label,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 36,
                        FontWeight = FontWeights.UltraBold
                    };

                    uniformGrid.Children.Add(textBlock);
                    
                    continue;
                }

                var boardTile = _board!.Tiles[row - 1, column - 1];
                Image? image = null;
                if (boardTile.CurrentChessToken != null)
                {
                    var color = boardTile.CurrentChessToken.ChessTokenColor == ChessTokenColor.White ? "White" : "Black";
                    var imageKey = $"{boardTile.CurrentChessToken.Name}_{color}";

                    _images.TryGetValue(imageKey, out var imageSource);
                    image = new Image
                    {
                        Width = 50,
                        Source = imageSource,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        StretchDirection = StretchDirection.Both,
                        Stretch = Stretch.Fill
                    };
                }

                var button = new Button
                {
                    Background = boardTile.Brush,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Content = image
                };

                uniformGrid.Children.Add(button);
            }
        }
    }

    private static void AddEmptyTile(UniformGrid uniformGrid)
    {
        uniformGrid.Children.Add(new TextBlock());
    }

    private static BitmapImage CreateBitmapImage(Uri uriSource)
    {
        var myBitmapImage = new BitmapImage();

        // BitmapImage.UriSource must be in a BeginInit/EndInit block
        myBitmapImage.BeginInit();
        myBitmapImage.UriSource = uriSource;
        myBitmapImage.DecodePixelWidth = 200;
        myBitmapImage.BaseUri = new Uri(AppContext.BaseDirectory);
        myBitmapImage.EndInit();

        return myBitmapImage;
    }

    public void Unload()
    {
        Debug.WriteLine("Unload game");
    }
}