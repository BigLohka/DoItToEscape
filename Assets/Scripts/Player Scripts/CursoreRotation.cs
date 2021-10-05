using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursoreRotation : MonoBehaviour
{
    [SerializeField]
    private float offset; // �������� �� �������
    void Start()
    {
    }

    void Update()
    {
        // ������ ������� �������� �������
        Vector3 diffrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        Vector3 localScale = Vector3.one; // �������� ���������

        if (rotateZ > 90 || rotateZ < 90)
        { localScale.y = -1f; }
        else
        { localScale.y = +1f; }

        transform.localScale = localScale;

        // ����� �������


    }
}
