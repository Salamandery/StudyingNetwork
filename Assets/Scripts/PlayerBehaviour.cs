using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : Character
{
    private static PlayerBehaviour instance;

    public static PlayerBehaviour MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerBehaviour>();
            }
            return instance;
        }
    }
    private Rigidbody rb;
    public Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move() {
        float hrz = Input.GetAxisRaw("Horizontal");
        float vt = Input.GetAxisRaw("Vertical");
        move = new Vector3(hrz, 0, vt).normalized;

        rb.velocity = move * Speed + new Vector3(0.0f, rb.velocity.y, 0.0f);
    }
}
