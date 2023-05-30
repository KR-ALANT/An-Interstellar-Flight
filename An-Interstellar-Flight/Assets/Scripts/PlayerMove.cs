using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed; //입력
    public float jumpPower; //입력
    Rigidbody2D rigid; //Rigidbody2D형 변수


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); //Rigidbody2D 가져오기
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        //Move
        if (h > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (h < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void FixedUpdate()
    {
            //Move Speed
            float h = Input.GetAxisRaw("Horizontal");
            rigid.velocity = new Vector2(maxSpeed * h, rigid.velocity.y);

            //Landing platform
            if (rigid.velocity.y < 0)
            {
                Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
                RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            }
    }
}