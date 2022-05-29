using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowentsSpawner : MonoBehaviour
{
    public GameObject[] SpherePowents;
    // Start is called before the first frame update

    bool hasInvoked = false;

    private void Start()
    {
        Spawn();
    }

    public void Spawn() 
    {
        int i = Random.Range(0, SpherePowents.Length-1);
        GameObject tempGO = Instantiate(SpherePowents[i], transform.position, transform.rotation);
        tempGO.transform.SetParent(transform);
        hasInvoked = false;
    }

    private void Update()
    {
        if (transform.childCount > 0)
            return;

        if (!hasInvoked) {
            hasInvoked = true;
            Invoke("Spawn", 5.0f);
        } 
    }

}
