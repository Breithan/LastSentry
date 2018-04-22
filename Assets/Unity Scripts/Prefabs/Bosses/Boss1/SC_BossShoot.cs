using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BossShoot : MonoBehaviour {

    public GameObject gbtLaserRed;
    public GameObject[] gbjParticle;
	public float Discord;

    void Start()
    {
        Discord /= PlayerPrefs.GetFloat("Hardship");
        InvokeRepeating("ExplodeSkill", 3, Discord / 2);
    }

    public void ExplodeSkill()
    {
        Vector2 activeLPos = new Vector2(this.transform.position.x, this.transform.position.y - 2);
        GameObject activeL = Instantiate(gbtLaserRed, activeLPos, this.transform.rotation);
        activeL.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -12);
        for (int i = 0; i < gbjParticle.Length; i++)
        {
            gbjParticle[i].GetComponent<ParticleSystem>().Play();
        }
        this.GetComponent<SC_AudioManager>().PlayAudio(2, 0.25f);
    }
}
