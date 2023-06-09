using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIrandomSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float freq;
    public int inScreenX_Minrange;
    public int inScreenX_Maxrange;
    public int inScreenY_Minrange;
    public int inScreenY_Maxrange;
    void Start()
    {
            StartCoroutine(spawnObjectOntime());  
    }
    IEnumerator spawnObjectOntime()
    {
        //Can change to any loop :) (while(true)is very danger.Careful if you will use it.)
        while (true)
        {
            yield return new WaitForSeconds(freq);
            GameObject prefabSpawned = Instantiate(prefabToSpawn, new Vector3(Random.Range(inScreenX_Minrange, inScreenX_Maxrange), Random.Range(inScreenY_Minrange, inScreenY_Maxrange), transform.position.z), transform.rotation);
            //use parent to add gameobject to canvas.
            prefabSpawned.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        }
    }

    void Update()
    {
        
    }
}
