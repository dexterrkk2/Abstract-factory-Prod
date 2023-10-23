using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public int endPointfar = 20;
    public int endPointClose = -30;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < endPointClose)
        {
            moveSpeed = -moveSpeed;
        }
        if (transform.position.z > endPointfar)
        {
            moveSpeed = -moveSpeed;
        }
        Vector3 movePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed);
        rb.MovePosition(movePosition);
    }
}
