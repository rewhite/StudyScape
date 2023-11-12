using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DetectPlane : MonoBehaviour
{

    public ARPlaneManager planeManager;
    public GameObject cubePrefab;
    public GameObject objectToMove;
    
    void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
                  // objectToMove.transform.position = plane.transform.position;
                // Instantiate(cubePrefab, plane.transform.position, Quaternion.identity);
            
        }
    }
}
