using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnEnable()
    {
        AppManager.Instance.utilityManager.OnPlayerLeftRotate += OnLeftRotate;
        AppManager.Instance.utilityManager.OnPlayerRightRotate += OnRightRotate;
        AppManager.Instance.utilityManager.OnPlayerAcceleration += OnAccelerate;
        AppManager.Instance.utilityManager.OnPlayerShooting += OnShoot;
    }

    private void OnDisable()
    {
        AppManager.Instance.utilityManager.OnPlayerLeftRotate -= OnLeftRotate;
        AppManager.Instance.utilityManager.OnPlayerRightRotate -= OnRightRotate;
        AppManager.Instance.utilityManager.OnPlayerAcceleration -= OnAccelerate;
        AppManager.Instance.utilityManager.OnPlayerShooting -= OnShoot;
    }

    private void OnLeftRotate()
    {
        Debug.Log("OnPlayerLeftRotate");
    }

    private void OnRightRotate()
    {
        Debug.Log("OnPlayerRightRotate");
    }

    private void OnAccelerate()
    {
        Debug.Log("OnAccelerate");
    }

    private void OnShoot()
    {
        Debug.Log("OnShoot");
    }
}
