using System;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;

    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    private void MoveCrosshair()
    {
        if (Mouse.current != null)
        {
            crosshair.position = Mouse.current.position.ReadValue();
        }
    }
}
