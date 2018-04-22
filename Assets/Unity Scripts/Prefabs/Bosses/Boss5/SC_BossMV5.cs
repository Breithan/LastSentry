using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BossMV5 : MonoBehaviour {

    void Start()
    {
        GameObject.Find("bgdPurple").GetComponent<SC_Background>().FinalON = true;
        GameObject.Find("bgdPurple").GetComponent<SC_Background>().IncomingVel = 8;

        moveOrientateY = true;
    }

    void Update()
    {
        if (this.transform.position.y >= 5) moveOrientateY = false;
        else if (this.transform.position.y <= 4) moveOrientateY = true;

        if (moveOrientateY) {
            foreach (SC_Oscilacion i in this.gameObject.GetComponentsInChildren<SC_Oscilacion>())
            {
                i.Go();
            }

            GameObject.Find("Game Camera").AddComponent<SC_Oscilacion>().Go();

            GameObject.Find("Game Camera").GetComponent<SC_Oscilacion>().Oscila = 0.25f;
            Destroy(this);
        }
        
        else transform.position -= new Vector3(0, Time.deltaTime * fltVelocity * 1.5f, 0);
    }

    #region Valores Privados
    private bool moveOrientateY;
    #endregion

    #region Valores Publicos
    public float fltVelocity;
    #endregion
}
