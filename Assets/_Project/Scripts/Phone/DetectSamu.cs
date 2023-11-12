using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectSamu : MonoBehaviour
{
    public UnityEvent samuInEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "samu")
        {
         //next text shown
         samuInEvent?.Invoke();
        }
    }
}
