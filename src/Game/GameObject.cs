using System;

namespace WpfChessApp.Game;

/// <summary>
/// Abstrakte Spieleklasse. Hiervon leiten alle am Spiel beteiligten Objekte ab!
/// </summary>
public  abstract class GameObject
{
    protected GameObject()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id{ get; }
    public abstract string Name{ get; }
}