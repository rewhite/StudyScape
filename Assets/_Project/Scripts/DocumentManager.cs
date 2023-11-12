using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentManager : MonoBehaviour
{
    public GameObject[] documents, buttons;


    public void ListButtonClicked(int index)
    {
        buttons[index].SetActive(false);
        documents[index].SetActive(true);
    }
    
    public void CloseButtonClicked(int index)
    {
        buttons[index].SetActive(true);
        documents[index].SetActive(false);
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
