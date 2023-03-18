using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class pressToStop : MonoBehaviour
{
    public List<char> keysList = new List<char>();
    private char selectedChar;
    public TMP_Text charText;
    public GameObject pressObj;
    public GameObject allCircle;
    protected SizeManager sizeManager;
    // Start is called before the first frame update
    void Start()
    {
        //I use puzzlePoint from sizeManager for less variable.
        sizeManager = pressObj.GetComponent<SizeManager>();
        selectedChar = keysList[Random.Range(0,keysList.Count-1)];
    }

    // Update is called once per frame
    void Update()
    {
        charText.text = selectedChar.ToString();
        Press();
    }
    public void Press()
    {
        if (Input.GetKeyDown(selectedChar.ToString())){
            if (pressObj.GetComponent<sizetoValue>().value<=pressObj.GetComponent<sizetoValue>().valueOfCircleRange)
            {
                sizeManager.point.Point_incresed();
                allCircle.SetActive(false);
            }
            else
            {
                sizeManager.point.Point_decresed();
                allCircle.SetActive(false);
            }
        }
    }
}
