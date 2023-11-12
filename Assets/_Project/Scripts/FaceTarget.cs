using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentStage == GameManager.GameStage.Ready)
        {
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetPosition);
        }
    }
}
