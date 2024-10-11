using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 movedirection;
    float horizontalInput;
    float verticalInput;
    Rigidbody2D m_Rigidbody2D;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector2(horizontalInput, verticalInput);
        m_Rigidbody2D.MovePosition(transform.position + movedirection * Time.deltaTime * speed);
    }
}
