using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BossBS2 : MonoBehaviour
{
	void Start()
    {
        Discord /= PlayerPrefs.GetFloat("Hardship");
        InvokeRepeating("ExplodeSkill", 3, Discord / 2);
    }

    public GameObject gobMissilRed;
    public GameObject[] gbjParticle;
    public float Discord;

    public void ExplodeSkill()
    {
        GameObject activeM1 = Instantiate(gobMissilRed, new Vector2(this.transform.position.x - 0.9f, this.transform.position.y - 1.5f), this.transform.rotation);
        activeM1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -12);

        GameObject activeM2 = Instantiate(gobMissilRed, new Vector2(this.transform.position.x + 0.9f, this.transform.position.y - 1.5f), this.transform.rotation);
        activeM2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -12);

        for (int i = 0; i < gbjParticle.Length; i++)
        {
            if (gbjParticle[i] != null)
            { gbjParticle[i].GetComponent<ParticleSystem>().Play(); }
        }

        this.GetComponent<SC_AudioManager>().PlayAudio(2, 0.25f);
    }
}
