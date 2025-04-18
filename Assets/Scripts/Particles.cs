using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem thrusterParticleSystem;
    [SerializeField] private PlayerMovement playerMovementScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(playerMovementScript.thrust)) {
            thrusterParticleSystem.Play();
        }
        else {
            thrusterParticleSystem.Stop();
        }
    }
}
