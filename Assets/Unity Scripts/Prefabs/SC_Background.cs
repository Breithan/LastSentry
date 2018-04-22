using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Background : MonoBehaviour
{
    public float BackVel { get; private set; }
    public float IncomingVel { private get; set; }
    public bool FinalON { private get; set; }

    private void Start()
    {
        FinalON = false;
    }

    private void Update()
    {
        float incoming = IncomingVel * Time.deltaTime;

        if (transform.position.y <= 5.25f)
        {
            transform.position = new Vector3(0, 13.25f, 15);
        }

        if (IncomingVel > 0)
        {
            IncomingVel -= incoming;

            if (FinalON)
                BackVel -= incoming;

            else
                BackVel += incoming;
        }

        else IncomingVel = 0;

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -BackVel);
    }
}
