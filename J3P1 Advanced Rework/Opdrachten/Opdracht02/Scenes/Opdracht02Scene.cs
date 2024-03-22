using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Scenes;

public class Opdracht02Scene : Scene
{
    private List<Waypoint> _waypoints = new();

    private List<Vector2> waypointPositions = new()
    {
    new Vector2(100, 50),
    new Vector2(150, 100),
    new Vector2(200, 50),
    new Vector2(300, 200),
    new Vector2(350, 250)
    };
    public override void LoadScene()
    {
        Texture2D playerTex = SceneManager.Instance.Manager.Load<Texture2D>("Knight");
        Texture2D shieldTex = SceneManager.Instance.Manager.Load<Texture2D>("Shield");
        Texture2D weaponTex = SceneManager.Instance.Manager.Load<Texture2D>("Weapon");
        Texture2D gateTex = SceneManager.Instance.Manager.Load<Texture2D>("Gate");
        Texture2D enemyTex = SceneManager.Instance.Manager.Load<Texture2D>("Enemy");
        Texture2D waypointTex = SceneManager.Instance.Manager.Load<Texture2D>("Flag");
        
        var bounds1 = new Vector2(100, 100);
        var bounds2 = new Vector2(800, 400);
        
        #region Objects Creation

        for (var i = 0; i < 100; i++)
        {
            var waypoint = new Waypoint(new Vector2(0, 0), waypointTex);
            waypoint.Position = waypoint.GetRandomPosition(bounds1, bounds2);
            GameObjects.Add(waypoint);
            _waypoints.Add(waypoint);
        }
        
        var player = new Player(new Vector2(playerTex.Width, playerTex.Height), playerTex, 250f, 10, 5);
        var shield = new Shield(new Vector2(WindowWidth / 2, WindowHeight / 4), shieldTex);
        var weapon = new Weapon(new Vector2(WindowWidth / 4, WindowHeight / 2), weaponTex);
        var gate = new Gate(new Vector2(WindowWidth / 1.25f, WindowHeight / 1.25f), gateTex, new MenuScene());
        
        var enemy1 = new Enemy(new Vector2(500, 200), enemyTex, 10, 5, 100, _waypoints);
        
        #endregion
        GameObjects.Add(player);
        GameObjects.Add(shield);
        GameObjects.Add(weapon);
        GameObjects.Add(gate);
        GameObjects.Add(enemy1);
        base.LoadScene();
    }
}