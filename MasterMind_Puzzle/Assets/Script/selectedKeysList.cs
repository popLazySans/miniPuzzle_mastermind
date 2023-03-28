using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedKeysList : MonoBehaviour
{
    public List<char> selectedKeys = new List<char>();
    // Start is called before the first frame update
    void Start()
    {

    }
    public void addKeysToList(char key)
    {
        selectedKeys.Add(key);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
