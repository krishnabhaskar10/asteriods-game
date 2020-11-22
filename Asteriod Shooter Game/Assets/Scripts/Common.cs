
public class Common
{
    public const string resPrefix = "Assets/Resources/";
    public const string alienShipEnemyPath = "Enemies/alienship";
    public const string asteriodEnemiesPath = "Enemies/asteriod";
    public const string spaceShipPlayerPath = "Players/spaceship";
    public const string inGameHUDPath = "HUD/Canvas";
    public const string gameElements = "GameElements";
    public const string bulletPrefabPath = "Players/bullet";
    public const string collisionEffectPrefab = "Players/collisionEffect";

    public const string jsonPath = "Sample.json";

    public enum PLAYERACTIONS
    {
        ROTATELEFT,
        ROTATERIGHT,
        ACCELERATE,
        SHOOT
    }

    public const float screenTop = 7f;
    public const float screenBottom = -7f;
    public const float screenLeft = -12f;
    public const float screenRight = 12f;
}
