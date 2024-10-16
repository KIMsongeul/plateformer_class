using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_legs : MonoBehaviour
{
    public float yMax = 2.0f;

    public float yMin = -2.0f;

    float currentPosition; //���� ��ġ(y) ����
 
    public float direction = 3.0f; //�̵��ӵ�+����




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

        //���� ��ġ(x)�� ��� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� ��� �̵������� (x)�ִ밪���� ����

        else if (currentPosition <= yMin)

        {

            direction *= -1;

            currentPosition = yMin;

        }

        //���� ��ġ(x)�� �·� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� �·� �̵������� (x)�ִ밪���� ����

        transform.position = new Vector3(0, currentPosition, 0);

        //"Stone"�� ��ġ�� ���� ������ġ�� ó��

    }
}
