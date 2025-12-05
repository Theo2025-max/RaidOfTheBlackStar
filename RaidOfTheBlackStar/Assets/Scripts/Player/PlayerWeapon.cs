using System;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

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
        MoveTargetPoint();
        AimLasers();
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

    private void MoveTargetPoint()
    {
        if (Mouse.current != null)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 targetPointPosition = new Vector3(mousePos.x, mousePos.y, targetDistance);
            targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
        }
    }

    private void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }

}
