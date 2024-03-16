using J3P1_Advanced_Rework.Opdrachten.Opdracht01.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.GameObjects;

public class Player : GameObject
{

    #region Keyboard

    private Keys _upKey = Keys.W;
    private Keys _leftKey = Keys.A;
    private Keys _rightKey = Keys.D;
    private Keys _downKey = Keys.S;
    private KeyboardState _keyboard;

    #endregion

    #region Variables

    private float _speed;

    #endregion

    #region Properties

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    #endregion
    public Player(Vector2 pPosition, Texture2D pTexture, float pSpeed) : base(pPosition, pTexture)
    {
        Speed = pSpeed;
    }

    public override void UpdateObject(GameTime pGameTime)
    {
        Movement(pGameTime);
        base.UpdateObject(pGameTime);
    }
    private void Movement(GameTime pGameTime)
    {
        Vector2 direction = new Vector2();
        
        if (_keyboard.IsKeyDown(_upKey))
            direction.Y--;
        if (_keyboard.IsKeyDown(_downKey))
            direction.Y++;
        if (_keyboard.IsKeyDown(_rightKey))
            direction.X++;
        if (_keyboard.IsKeyDown(_leftKey))
            direction.X--;
        if (direction == Vector2.Zero) return;
        Position += direction * Speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
    }
}