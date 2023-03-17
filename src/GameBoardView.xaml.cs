using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using WpfChessApp.Game;

namespace WpfChessApp
{
    public partial class GameBoardView : Window
    {
        private readonly DispatcherTimer _graphicsTimer;
        private GameLoop _gameLoop;
        private ChessTokenColor _currentPlayer;

        public GameBoardView()
        {
            InitializeComponent();

            // Initialize graphics Timer
            _graphicsTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(1000 / 120)
            };
            _graphicsTimer.Tick += GraphicsTimer_Tick;
        }

        public string? CurrentChessToken { get; set; }

        public ChessTokenColor CurrentPlayer 
        {
            get => _currentPlayer;
            set
            {
                _currentPlayer = value;
                LblCurrentPlayer.Content = _currentPlayer.ToString();
                switch (_currentPlayer)
                {
                    case ChessTokenColor.Black:
                        LblCurrentPlayer.Foreground = Brushes.White;
                        LblCurrentPlayer.Background = Brushes.Black;
                        break;
                    case ChessTokenColor.White:
                        LblCurrentPlayer.Foreground = Brushes.Black;
                        LblCurrentPlayer.Background = Brushes.White;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void GraphicsTimer_Tick(object? sender, EventArgs e)
        {
            _gameLoop.Draw(ChessGrid);
        }

        private void GameBoardView_OnLoaded(object sender, RoutedEventArgs e)
        {
            CurrentPlayer = ChessTokenColor.White;

            // Initialize Game
            var myGame = new Game.Game
            {
                Resolution = new Size(SystemParameters.PrimaryScreenWidth, SystemParameters.PrimaryScreenHeight)
            };

            // Initialize & Start GameLoop
            _gameLoop = new GameLoop();
            _gameLoop.Load(myGame);
            _gameLoop.Start();

            // Start Graphics Timer
            _graphicsTimer.Start();
        }

        private void BtnSetNewPosition_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentChessToken == null) return;

            _gameLoop.UpdateGame(new GameContext(CurrentPlayer, TxtNewPosition.Text, CurrentChessToken));

            switch (CurrentPlayer)
            {
                case ChessTokenColor.Black:
                    CurrentPlayer = ChessTokenColor.White;
                    break;
                case ChessTokenColor.White:
                    CurrentPlayer = ChessTokenColor.Black;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            CurrentChessToken = ((RadioButton)sender).Tag!.ToString();
        }
    }
}