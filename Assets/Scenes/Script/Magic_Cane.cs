using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Cane : MonoBehaviour
{
    [Header("Cane_Move")]
    float rightMax = 2.0f; //�·� �̵������� (x)�ִ밪
    float leftMax = -2.0f; //��� �̵������� (x)�ִ밪
    float currentPosition; //���� ��ġ(x) ����
    float direction = 3.0f; //�̵��ӵ�+����

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

        currentPosition = transform.position.x;

    }

    void Update()

    {

        currentPosition += Time.deltaTime * direction;

        if (currentPosition >= rightMax)

        {

            direction *= -1;

            currentPosition = rightMax;

        }
        //���� ��ġ(x)�� ��� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� ��� �̵������� (x)�ִ밪���� ����

        else if (currentPosition <= leftMax)

        {

            direction *= -1;

            currentPosition = leftMax;

        }
        //���� ��ġ(x)�� �·� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�
        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� �·� �̵������� (x)�ִ밪���� ����

        transform.position = new Vector3(currentPosition, 0, 0);

        //"Magic_Cane"�� ��ġ�� ���� ������ġ�� ó��

    }

}
