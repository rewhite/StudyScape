using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{

    public GameObject bookTooltip, bookList;

    private void Awake()
    {
        bookTooltip.SetActive(true);
        bookList.SetActive(false);
    }

    public void ToggleFinder()
    {
        bookTooltip.SetActive(!bookTooltip.activeSelf);
        bookList.SetActive(!bookList.activeSelf);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
