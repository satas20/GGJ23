using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
   

    private void Start()
    {
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ceset"))
        {
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Perform the pickup logic here
                Debug.Log("Picked up item!");
            }
        }
    }
    private void Update()
    {
            
    }
}
