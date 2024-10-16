using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_move : MonoBehaviour
{
    public float circleR; // 반지름
    public float objSpeed; // 원운동 속도
    private float deg; // 각도

    public GameObject[] YS; 

    void Start()
    {
        deg = 0; 
    }

    void Update()
    {
        deg += Time.deltaTime * objSpeed;
        if (deg >= 360) 
        {
            deg -= 360;
        }

        var rad = Mathf.Deg2Rad * deg;
        var x = circleR * Mathf.Sin(rad);
        var y = circleR * Mathf.Cos(rad);

        if (YS.Length > 0) 
        {
            YS[0].transform.position = transform.position + new Vector3(x, y, 0);
            
        }
    }
}
