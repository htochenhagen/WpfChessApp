namespace WpfChessApp.Game;

/// <summary>
/// Abstrakte Spieleklasse. Hiervon leiten alle am Spiel beteiligten Objekte ab!
/// </summary>
public  abstract class GameObject
{
    public abstract string Name{ get; }
}