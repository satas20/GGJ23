using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reborn : MonoBehaviour
{
    private bool rebornNow;
    public float rebornTime;
    private WaitForSeconds rebornTimeWait;
    public GameObject reborningEnemy;
    private void Awake()
    {
        rebornTimeWait = new WaitForSeconds(rebornTime);
        rebornNow = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CounteRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(rebornNow)
        {
            rebornNow = false;
            GameObject enemy = Instantiate(reborningEnemy, transform.position, Quaternion.identity);
            enemy.name = enemy.name.Substring(0, enemy.name.IndexOf('('));

            Destroy(this.gameObject);
        }
    }

    IEnumerator CounteRoutine()
    {
        yield return rebornTimeWait;
        rebornNow=true;
    }
}
