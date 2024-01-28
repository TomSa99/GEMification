using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapController : MonoBehaviour, IPointerClickHandler
{
    public Color highlightedColor;
    public GameObject areaToHighlight; // Set this in the Inspector

    private Color defaultColor;

    private void Start()
    {
        Debug.Log("MapController script started");

        // Store the default color of the area to highlight
        defaultColor = areaToHighlight.GetComponent<SpriteRenderer>().color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click detected");
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.CompareTag("MapRegion"))
        {
            Debug.Log("Region clicked");
            // This is a region on the map
            GameObject regionObject = hit.collider.gameObject;
            regionObject.GetComponent<SpriteRenderer>().color = highlightedColor;

            // Display additional information
            // ...
        }
    }

    public void HighlightArea()
    {
        // Highlight the area by changing its color
        areaToHighlight.GetComponent<SpriteRenderer>().color = highlightedColor;
    }

    public void UnhighlightArea()
    {
        // Unhighlight the area by changing its color back to the default color
        areaToHighlight.GetComponent<SpriteRenderer>().color = defaultColor;
    }
}
