using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuManager : MonoBehaviour
{
    public GameObject[] tooltips;

    public Animator finderAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePosition()
    {
        
    }

    public void SamuOnThePhone()
    {
        tooltips[0].SetActive(false);
        tooltips[1].SetActive(true);

        Invoke(nameof(summonBook), 1.5f);
    }


    private void summonBook()
    {

        finderAnimator.SetTrigger("Appear");

        Invoke(nameof(hideTootipSamu), 1f);
    }

    private void hideTootipSamu()
    {
        tooltips[1].SetActive(false);
    }

    public void showHandGuide()
    {
        Invoke(nameof(_showHandGuide), 1f);

    }

    public void _showHandGuide()
    {

        tooltips[2].SetActive(true);
    }
}


