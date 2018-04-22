using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FinalGame : MonoBehaviour {

	void Start ()
    {
		
	}
	
	void Update ()
    {
        fltAutoMove += Time.deltaTime;
        float incoming = fltAutoMove * 0.6666666667f;
        transform.position += new Vector3(0, incoming, 0);
    }

    #region Valores
    private float fltAutoMove;
    #endregion

}
