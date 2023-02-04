using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject[] shacks;

    private void Start()
    {
        shacks = GameObject.FindGameObjectsWithTag("Shack");
        int randomIndex = Random.Range(0, shacks.Length);
        transform.position = shacks[randomIndex].transform.position;
    }
}
