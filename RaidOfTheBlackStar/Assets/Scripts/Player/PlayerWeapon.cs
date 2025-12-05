using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    
    bool isFiring = false;

    public void OnFire(InputValue value)
    {
       isFiring = value.isPressed;
    }

    private void Update()
    {
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;

        }


    }
}
