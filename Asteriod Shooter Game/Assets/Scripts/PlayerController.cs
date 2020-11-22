using UnityEngine;

public interface IFlyer
{
    void LeftRotate();
    void RightRotate();
    void Accelerate();
    void Shoot();
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, IFlyer
{
    public Common.PLAYERACTIONS playerActions;

    private Rigidbody2D rigidbody = null;
    public float rotationSpeed = 10f;
    private float multiplier = 1.0f;

    public Transform firePoint = null;
    public float bulletForce = 20f;
    

    private void OnEnable()
    {
        AppManager.Instance.utilityManager.OnPlayerLeftRotate += LeftRotate;
        AppManager.Instance.utilityManager.OnPlayerRightRotate += RightRotate;
        AppManager.Instance.utilityManager.OnPlayerAcceleration += Accelerate;
        AppManager.Instance.utilityManager.OnPlayerShooting += Shoot;
    }

    private void OnDisable()
    {
        AppManager.Instance.utilityManager.OnPlayerLeftRotate -= LeftRotate;
        AppManager.Instance.utilityManager.OnPlayerRightRotate -= RightRotate;
        AppManager.Instance.utilityManager.OnPlayerAcceleration -= Accelerate;
        AppManager.Instance.utilityManager.OnPlayerShooting -= Shoot;
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void LeftRotate()
    {
        playerActions = Common.PLAYERACTIONS.ROTATELEFT;
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + rotationSpeed);
    }

    public void RightRotate()
    {
        playerActions = Common.PLAYERACTIONS.ROTATERIGHT;
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - rotationSpeed);
    }
    
    public void Accelerate()
    {
        multiplier = 1.0f;
        playerActions = Common.PLAYERACTIONS.ACCELERATE;               
    }

    public void Shoot()
    {
        playerActions = Common.PLAYERACTIONS.SHOOT;
        StartCoroutine(AppManager.Instance.resourceManager.LoadGameObject(Common.bulletPrefabPath, OnBulletLoaded));
    }

    private void OnBulletLoaded(GameObject _go)
    {
        _go.transform.position = firePoint.position;
        _go.transform.rotation = firePoint.rotation;
        _go.transform.SetParent(firePoint);

        Rigidbody2D rb = _go.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        switch (playerActions)
        {
            case Common.PLAYERACTIONS.ROTATELEFT:
                //transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + 5f);
                //transform.Rotate(0, 0, 5f * Time.deltaTime);
                break;
            case Common.PLAYERACTIONS.ROTATERIGHT:
                //transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - 5f);
                //transform.Rotate(0, 0, -5f * Time.deltaTime);
                break;
            case Common.PLAYERACTIONS.ACCELERATE:
                transform.position += transform.up * multiplier * Time.deltaTime;
                multiplier *= 0.95f;
                break;
            case Common.PLAYERACTIONS.SHOOT:
                break;
            default:
                break;
        }
    }
}
