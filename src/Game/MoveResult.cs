namespace WpfChessApp.Game
{
    public class MoveResult
    {
        public MoveResult(bool success, string? failMessage = null)
        {
            Success = success;
            FailMessage = failMessage;
        }

        public bool Success { get; }
        public string? FailMessage{ get; }
    }
}
