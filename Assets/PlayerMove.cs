using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 movedirection;
    float horizontalInput;
    float verticalInput;
    Rigidbody2D m_Rigidbody;
    public float speed = 5f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector2(horizontalInput, verticalInput);
        m_Rigidbody.MovePosition(transform.position + movedirection * Time.deltaTime * speed);
    }
}
