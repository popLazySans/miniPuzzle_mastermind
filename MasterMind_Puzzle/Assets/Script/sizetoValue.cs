using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizetoValue : MonoBehaviour
{
    private SizeManager sizeManager;
    public GameObject circleRange_Object;
    public float value;
    public float valueOfCircleRange;
    // Start is called before the first frame update
    void Start()
    {
        sizeManager = gameObject.GetComponent<SizeManager>();
    }
    void Update()
    {
        //can change for other scale
        value = sizeManager.x_scale;
        valueOfCircleRange = circleRange_Object.transform.localScale.x;
    }

}
