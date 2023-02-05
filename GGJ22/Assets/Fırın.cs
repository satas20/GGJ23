using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fırın : MonoBehaviour
{
    // Start is called before the first frame update
    void setFalse(){
        GetComponent<Animator>().SetBool("isBurn", false);
    }
}
