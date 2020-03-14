using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCodeScript : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;

    void update ()
    {
        if(Input.GetMouseButton(0))
        {
            Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
        }
      
    }
}
