using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BossBS5 : MonoBehaviour {

    void Start()
    {
        fltBullet = 0;
        InvokeRepeating("ExplodeSkill", 0, Discord);
        InvokeRepeating("RestartInvoke", 2 / PlayerPrefs.GetFloat("Hardship"), 2 / PlayerPrefs.GetFloat("Hardship"));
    }

    #region Atributos
    private float fltBullet;
    #endregion

    #region Propiedaes
    public GameObject gobMissilRed;
    public GameObject[] gbjParticle;
    public float Discord;
    #endregion

    public void ExplodeSkill()
    {
        if (fltBullet < 3)
        {
            GameObject activeM1 = Instantiate(gobMissilRed, new Vector2(this.transform.position.x - 0.8f, this.transform.position.y - 1.5f), this.transform.rotation);
            activeM1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -15);

            GameObject activeM2 = Instantiate(gobMissilRed, new Vector2(this.transform.position.x + 0.8f, this.transform.position.y - 1.5f), this.transform.rotation);
            activeM2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -15); ;

            for (int i = 0; i < gbjParticle.Length; i++)
            {
                gbjParticle[i].GetComponent<ParticleSystem>().Play();
            }

            this.GetComponent<SC_AudioManager>().PlayAudio(2, 0.25f);
        }

        fltBullet++;
    }

    public void RestartInvoke()
    {
        fltBullet = 0;
    }
}
