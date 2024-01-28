using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public float zoomSpeed = 0.1f;
    public float moveSpeed = 1f;
    public float minZoom = 0.5f;
    public float maxZoom = 2f;

    private Vector3 previousMousePosition;

    private void Update()
    {
        // Zoom in/out with the mouse scroll wheel
        float zoomDelta = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        float newScale = Mathf.Clamp(transform.localScale.x + zoomDelta, minZoom, maxZoom);
        transform.localScale = new Vector3(newScale, newScale, 1f);

        // Move the map with the mouse drag
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
            transform.position += mouseDelta * moveSpeed;
        }

        // Store the current mouse position for the next frame
        previousMousePosition = Input.mousePosition;
    }
}
