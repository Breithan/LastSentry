using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_TopColl : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player Laser")
        {
            Destroy(coll.gameObject);
        }
    }
}
