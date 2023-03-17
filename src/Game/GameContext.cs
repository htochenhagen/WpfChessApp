namespace WpfChessApp.Game
{
    public class GameContext
    {
        public GameContext(ChessTokenColor currentPlayer, string newPosition, string currentChessToken)
        {
            CurrentPlayer = currentPlayer;
            NewPosition = newPosition;
            CurrentChessToken = currentChessToken;
        }

        public ChessTokenColor CurrentPlayer { get; }
        public string CurrentChessToken { get; }
        public string NewPosition { get; }
    }
}
