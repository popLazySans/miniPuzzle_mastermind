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
    private int randomNumber;
    private selectedKeysList selectedKeysList;
    private Mastermind_Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        //get selected keyslist and Spawner scripts from tag object
        selectedKeysList = GameObject.FindGameObjectWithTag("Spawner").GetComponent<selectedKeysList>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Mastermind_Spawner>();
        //I use puzzlePoint from sizeManager for less variable.
        sizeManager = pressObj.GetComponent<SizeManager>();
        RandomNumberWithoutNotSelected();
        selectedChar = keysList[randomNumber];
        selectedKeysList.addKeysToList(selectedChar);
    }
    //Can change to return method if you want :)
    public void RandomNumberWithoutNotSelected()
    {
        bool isCorrectRandomNumber = false;
        while (true)
        {
            if (isCorrectRandomNumber == false)
            {
                randomNumber = Random.Range(0, keysList.Count - 1);
                if (selectedKeysList.selectedKeys.Count != 0)
                {
                    foreach (char i in selectedKeysList.selectedKeys)
                    {
                        if (keysList[randomNumber] == i) { //Debug.Log("has Selected!!!" + keysList[randomNumber]); 
                            isCorrectRandomNumber = false; break; }
                        else { //Debug.Log("Ok" + keysList[randomNumber]); 
                            isCorrectRandomNumber = true; }
                    }
                }
                else
                {
                    //Debug.Log(keysList[randomNumber]);
                    break;
                }
            }
            else
            {
                //Debug.Log(keysList[randomNumber]);
                break;
            }
        }
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
                //Add sucess count
                spawner.destroyCount += 1;
                spawner.Success();
                //Legacy
                sizeManager.point.Point_incresed();
                allCircle.SetActive(false);
            }
            else
            {
                //Add failed if miss
                spawner.destroyCount += 1;
                spawner.Failed();
                //Legacy
                sizeManager.point.Point_decresed();
                allCircle.SetActive(false);
            }
        }
    }
}
