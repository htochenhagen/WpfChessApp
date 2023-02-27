using System;
using System.Windows;
using System.Windows.Threading;
using WpfChessApp.Game;

namespace WpfChessApp
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _graphicsTimer;
        private GameLoop _gameLoop;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize graphics Timer
            _graphicsTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(1000 / 120)
            };
            _graphicsTimer.Tick += GraphicsTimer_Tick;
        }

        private void GraphicsTimer_Tick(object? sender, EventArgs e)
        {
            _gameLoop.Draw();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

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
    }
}