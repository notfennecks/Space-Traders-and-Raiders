using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 dragOrigin;
    
    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;
    private void Update()
    {
        PanCamera();
        ZoomIn();
    }

    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(2))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(2))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }
    }

    private void ZoomIn()
    {
        if(Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float newSize = cam.orthographicSize - (zoomStep * Input.GetAxis("Mouse ScrollWheel"));
            cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
        }
    }
}
