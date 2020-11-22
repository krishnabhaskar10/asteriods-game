using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteriod : MonoBehaviour
{
    public float maxThrust = 0f;
    public float maxTorque = 0f;
    private Rigidbody2D rb = null;
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 thrust = new Vector2(
            Random.Range(-maxThrust, maxThrust),
            Random.Range(-maxThrust, maxThrust)
            );

        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }
       
    void Update()
    {
        ScreenWrapping();
    }

    private void ScreenWrapping()
    {
        Vector2 newPos = transform.position;

        if (transform.position.y > Common.screenTop)
        {
            newPos.y = Common.screenBottom;
        }
        if (transform.position.y < Common.screenBottom)
        {
            newPos.y = Common.screenTop;
        }
        if (transform.position.x > Common.screenRight)
        {
            newPos.x = Common.screenLeft;
        }
        if (transform.position.x < Common.screenLeft)
        {
            newPos.x = Common.screenRight;
        }

        transform.position = newPos;
    }

}
