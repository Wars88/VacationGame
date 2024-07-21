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
        // Animator의 Speed크기를 inputVec의 크기로 설정 
        animator.SetFloat("Speed", inputVec.magnitude);

        // 바라보는 방향에 따라 반전
        if (inputVec.x != 0)
            sprite.flipX = inputVec.x > 0;

        // 죽는 모션의 크기 설정
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
