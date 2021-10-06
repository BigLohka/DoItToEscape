using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [Header("Parametrs")] //��������
    [SerializeField]
    private float CharacterSpeed = 5f;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector3 posFlip;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float jumpForce = 5f;

    private Vector2 CharacterMoveVector;
    [Header("Ground Check")] //������
    [SerializeField]
    private bool onGround;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float checkRadius = 0.5f;
    [SerializeField]
    private LayerMask ground;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        CharacterMoving();
        // ������ ������� �������� �������
        Vector3 diffrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //����� �������
        //������ ������
        Jump();
        CheckingGround();
        //����� �������

        //������ �� ������� ���������
        Flip();
        posFlip = mainCamera.WorldToScreenPoint(transform.position);
        //����� �������
    }

    private void CharacterMoving() // �������� ������
    {
        CharacterMoveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(CharacterMoveVector.x * CharacterSpeed, rb.velocity.y);
    }
    private void Flip() //������ ��������
    {
        if(Input.mousePosition.x < posFlip.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.mousePosition.x > posFlip.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            //���� �� ����� ������ rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
    }


}
