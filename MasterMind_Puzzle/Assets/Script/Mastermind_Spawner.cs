using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Mastermind_Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float freqPerRound;
    public float freqInRound;
    public int inScreenX_Minrange;
    public int inScreenX_Maxrange;
    public int inScreenY_Minrange;
    public int inScreenY_Maxrange;
    private selectedKeysList selectedKeysList;
    public Puzzle_Point puzzle_Point;
    public int SuccessState;
    internal bool isFail = false;
    public TMP_Text SucessText;
    internal int destroyCount = 0;
    void Start()
    {
        selectedKeysList = gameObject.GetComponent<selectedKeysList>();
        StartCoroutine(spawnObjectOntime());
    }
    IEnumerator spawnObjectOntime()
    {
        //Can change to any loop :) (while(true)is very danger.Careful if you will use it.)
        while (SuccessState > 0)
        {
            yield return new WaitForSeconds(freqPerRound);
            destroyCount = 0;
            StartCoroutine(spawnObjectThreeTime());
            RemoveAllSelectedKeysFromList();
            puzzle_Point.resetPointGroup();
            SuccessState -= 1;
            if (isFail)
            {
                break;
            }
        }
    }
    IEnumerator spawnObjectThreeTime()
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(freqInRound);
            spawnObject();
        }
    }
    public void RemoveAllSelectedKeysFromList()
    {
        selectedKeysList.selectedKeys.Clear();
        
    }
    public void spawnObject()
    {
        if (isFail == false)
        {
            GameObject prefabSpawned = Instantiate(prefabToSpawn, new Vector3(Random.Range(inScreenX_Minrange, inScreenX_Maxrange), Random.Range(inScreenY_Minrange, inScreenY_Maxrange), transform.position.z), transform.rotation);
            //use parent to add gameobject to canvas.
            prefabSpawned.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        }
    }
    public void Success()
    {
        if (SuccessState == 0 && destroyCount == 3 && isFail == false)
        {
            SucessText.text = "Success";
        }
    }
    public void Failed()
    {
        isFail = true;
        SucessText.text = "Fail";
    }
    void Update()
    {
       
    }
}
