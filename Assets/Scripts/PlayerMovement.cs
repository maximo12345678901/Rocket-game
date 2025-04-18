using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode thrust;
    public KeyCode turnLeft;
    public KeyCode turnRight;

    [Header("Components")]
    [SerializeField] Rigidbody2D playerRb;

    [Header("Adjustable variables")]
    [SerializeField] float thrustForce;
    [SerializeField] float turningForce;
    // Update is called once per frame
    void Update()
    {
        Movement(transform.up);
    }

    void Movement(Vector3 thrustDirection)
    {
        if(Input.GetKey(thrust)) {
            playerRb.AddForce(thrustDirection * thrustForce);
        }
        if(Input.GetKey(turnLeft)) {
            playerRb.AddTorque(turningForce);
        }
        if (Input.GetKey(turnRight)) {
            playerRb.AddTorque(-turningForce);
        }
    }
}
