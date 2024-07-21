using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;

    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private Animator animator;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        scanner = gameObject.GetComponent<Scanner>();   
    }


    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        // Animator�� Speedũ�⸦ inputVec�� ũ��� ���� 
        animator.SetFloat("Speed", inputVec.magnitude);

        // �ٶ󺸴� ���⿡ ���� ����
        if (inputVec.x != 0)
            sprite.flipX = inputVec.x > 0;

        // �״� ����� ũ�� ����
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
