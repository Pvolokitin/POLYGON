using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;       // LayerMask = Ground

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);     // Launching a beam from the camera
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            transform.position = raycastHit.point;      //  Move the crosshair behind the mouse cursor
        }
    }
}
