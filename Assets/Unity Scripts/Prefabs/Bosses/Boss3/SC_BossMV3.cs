using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BossMV3 : MonoBehaviour {

    void Start()
    {
        moveOrientateY = true;
    }

    void Update()
    {
        if (this.transform.position.y >= 4f) moveOrientateY = false;
        else if (this.transform.position.y <= 2.5f) moveOrientateY = true;

        if (moveOrientateY) this.transform.position += new Vector3(0, Time.deltaTime * fltVelocity, 0);
        else this.transform.position -= new Vector3(0, Time.deltaTime * fltVelocity * 2, 0);
    }

    #region Valores Privados
    private bool moveOrientateY;
    #endregion

    #region Valores Publicos
    public float fltVelocity;
    #endregion
}
