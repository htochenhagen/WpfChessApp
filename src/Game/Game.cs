using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

    public void Update(TimeSpan gameTime)
    {
        Debug.WriteLine("Update game");
    }

    public void Draw(UniformGrid uniformGrid)
    {
        Debug.WriteLine("Draw game");

        uniformGrid.Children.Clear();
        foreach (var boardTile in _board!.Tiles)
        {
            Image? image = null;
            if (boardTile.CurrentChessToken != null)
            {
                var color = boardTile.CurrentChessToken.ChessTokenType == ChessTokenType.White ? "White" : "Black";
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