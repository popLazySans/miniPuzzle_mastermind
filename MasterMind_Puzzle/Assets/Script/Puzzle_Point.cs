using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Puzzle_Point : MonoBehaviour
{
    internal int point = 0;
    internal int combo = 0;
    public TMP_Text pointText;
    public TMP_Text comboText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Score : "+point.ToString();
        comboText.text = "Combo : " + combo.ToString();
    }
    public void Point_decresed()
    {
        Debug.Log("Fail");
        if (point > 0)
        {
            point -= 1;
        }
        if(combo != 0)
        {
            combo = 0;
        }
    }
    public void Point_incresed()
    {
        Debug.Log("WoW");
        combo += 1;
        point += 1;
    }
}
