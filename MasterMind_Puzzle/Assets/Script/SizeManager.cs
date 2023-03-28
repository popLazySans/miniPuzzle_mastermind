using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SizeManager : MonoBehaviour
{
    //Can change to private and GetComponent this object
    public GameObject addsizeImage;
    public pressToStop pressToStop;
    internal Puzzle_Point point;
    internal Mastermind_Spawner spawner;
    public float x_scale;
    public float y_scale;
    public float z_scale;
    public float speed;

    private bool isWorked = false;
    // Start is called before the first frame update
    private void Start()
    {
        //Can change to any search but I use tag because it's eazy.
        point = GameObject.FindGameObjectWithTag("PointManager").GetComponent<Puzzle_Point>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Mastermind_Spawner>();
        x_scale = addsizeImage.GetComponent<Transform>().localScale.x;
        y_scale = addsizeImage.GetComponent<Transform>().localScale.y;
        z_scale = addsizeImage.GetComponent<Transform>().localScale.z;
    }
    void Update()
    {
        x_scale = Decease_scale(x_scale);
        y_scale = Decease_scale(y_scale);
        z_scale = Decease_scale(z_scale);
        addsizeImage.transform.localScale = new Vector3(x_scale,y_scale,z_scale);

    }

    public float Decease_scale(float scale)
    {
        if (scale > 0)
        {
            scale -= 0.1f*speed*Time.deltaTime;
           
        }
        else
        {
            //have something bug.It worked 3 time in one condition.IDK why? (Maybe update again -_-)
            if(isWorked == false)
            {
               //Add failed
               spawner.destroyCount += 1;
               spawner.Failed();
               //Legacy
              point.Point_decresed();
              isWorked = true;
            }
            pressToStop.allCircle.SetActive(false);
        }
        return scale;
    }

}
