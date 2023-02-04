using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject[] kabin;

    private void Start()
    {
        kabin = GameObject.FindGameObjectsWithTag("Shack");
        int randomIndex = Random.Range(0, kabin.Length);
        transform.position = kabin[randomIndex].transform.position;
    }
}
