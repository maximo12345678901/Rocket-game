using UnityEngine;

public class ParticleJitterFix : MonoBehaviour
{
    [SerializeField] Transform target;
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = (target.transform.position - transform.position)*50;
    }
}
