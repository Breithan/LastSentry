using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BackMeteor : MonoBehaviour {

    public float flt_MetVel; // Velocidad del Meteoro
    public GameObject bgdPurple;

    private void Start()
    {
        bgdPurple = GameObject.Find("bgdPurple");
    }

    public void Update() {
        if (flt_MetVel != bgdPurple.GetComponent<SC_Background>().BackVel)
        {
            flt_MetVel = bgdPurple.GetComponent<SC_Background>().BackVel;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -(flt_MetVel + flt_MetVel * 0.25f));
        }
    }

}
