using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_legs : MonoBehaviour
{
    public float yMax = 2.0f;

    public float yMin = -2.0f;

    float currentPosition; //현재 위치(y) 저장
 
    public float direction = 3.0f; //이동속도+방향




    void Start()

    {

        currentPosition = transform.position.y;

    }




    void Update()

    {

        currentPosition += Time.deltaTime * direction;

        if (currentPosition >= yMax)

        {

            direction *= -1;

            currentPosition = yMax;

        }

        //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면

        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정

        else if (currentPosition <= yMin)

        {

            direction *= -1;

            currentPosition = yMin;

        }

        //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면

        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정

        transform.position = new Vector3(0, currentPosition, 0);

        //"Stone"의 위치를 계산된 현재위치로 처리

    }
}
