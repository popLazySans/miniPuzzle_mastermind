using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Puzzle_Point : MonoBehaviour
{
    internal int point = 0;
    internal int combo = 0;
    internal int ingroupPoint = 0;
    public TMP_Text pointText;
    public TMP_Text comboText;
    public TMP_Text inGroupText;
    public TMP_Text CompleteText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Score : " + point.ToString();
        comboText.text = "Combo : " + combo.ToString();
        inGroupText.text = "GroupPoint = " + ingroupPoint.ToString();
        Complete();
    }
    public void Point_decresed()
    {
        //Debug.Log("Fail");
        if (point > 0)
        {
            point -= 1;
        }
        if (combo != 0)
        {
            combo = 0;
        }
    }
    public void Point_incresed()
    {
        //Debug.Log("WoW");
        combo += 1;
        point += 1;
        ingroupPoint += 1;
    }
    public void Complete()
    {
        if(ingroupPoint == 3)
        {
           CompleteText.text = "Complete";
           StartCoroutine(ActiveFalseOntime());
        }
    }
    public void resetPointGroup()
    {
        ingroupPoint = 0;
        StartCoroutine(ActiveFalseOntime());
    }
    IEnumerator ActiveFalseOntime()
    {
        ingroupPoint = 0;
        yield return new WaitForSeconds(2f);
        CompleteText.text = "";
    }
    
}
