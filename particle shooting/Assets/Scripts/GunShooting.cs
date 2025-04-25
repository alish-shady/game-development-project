using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public ParticleSystem GunParticles;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            GunParticles.Play();
        }
    }
}
