using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject collision = null;

    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Enemies")
        {
            collision = _collision.gameObject;
            
            StartCoroutine(AppManager.Instance.resourceManager.LoadGameObject(Common.collisionEffectPrefab, OnCollisionDetected));
        }        
    }

    public void OnCollisionDetected(GameObject _go)
    {
        _go.transform.SetParent(collision.transform, false);
        Destroy(collision.gameObject, 0.4f);
    }

}
