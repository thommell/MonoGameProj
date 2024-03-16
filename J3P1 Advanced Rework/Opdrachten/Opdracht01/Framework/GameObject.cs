#region Library

using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.Framework;

public class GameObject
{
    #region Variables
    
    private Vector2 _position;
    private Vector2 _origin;
    private Texture2D _texture;
    private Rectangle _rectangle;
    private float _rotation;
    
    #endregion
    #region Properties

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }
    public Vector2 Origin
    { 
        get => _origin;
        set => _origin = value;
    }
    public Texture2D Texture
    {
        get => _texture;
        set => _texture = value;
    }
    public Rectangle Rectangle
    {
        get => _rectangle;
        set => _rectangle = value;
    }

    public float Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }
    #endregion
    protected GameObject(Vector2 pPosition, Texture2D pTexture)
    {
        Position = pPosition;
        Texture = pTexture;
        Origin = GetOrigin();
    }
    public virtual void LoadObject() {}
    public virtual void UpdateObject(GameTime pGameTime) {
        Rectangle = new Rectangle((int)_position.X, (int)_position.Y , Texture.Width, Texture.Height);
    }
    private Vector2 GetOrigin()
    {
        return new Vector2(Texture.Width * 0.5f, Texture.Height * 0.5f);
    }
    public virtual void DrawObject(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Draw(Texture, _position, null, Color.White, 0f, Origin, Vector2.One, SpriteEffects.None, 0f);
    }
}