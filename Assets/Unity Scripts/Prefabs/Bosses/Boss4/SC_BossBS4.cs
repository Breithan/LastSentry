using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BossBS4 : MonoBehaviour {

    void Start()
    {
        fltBullet = 0;
        RestartDiscord = PlayerPrefs.GetFloat("Hardship");
        InvokeRepeating("ExplodeSkill", 3, Discord);
        InvokeRepeating("RestartInvoke", 5 / RestartDiscord, 2 / RestartDiscord);
    }

    #region Atributos
    private float fltBullet;
    private float RestartDiscord;
    #endregion

    #region Propiedaes
    public GameObject gobMissilRed;
    public GameObject[] gbjParticle;
    public float Discord;
    #endregion

    public void ExplodeSkill()
    {
        if (fltBullet < 5)
        {
            GameObject activeM1 = Instantiate(gobMissilRed, new Vector2(this.transform.position.x - 0.9f, this.transform.position.y - 2f), this.transform.rotation);
            activeM1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -15);

            GameObject activeM2 = Instantiate(gobMissilRed, new Vector2(this.transform.position.x + 0.85f, this.transform.position.y - 2f), this.transform.rotation);
            activeM2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -15);

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
