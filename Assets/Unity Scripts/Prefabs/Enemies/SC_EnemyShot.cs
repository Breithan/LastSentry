using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnemyShot : MonoBehaviour {

    void Start()
    {
        fltexplodeSkill /= PlayerPrefs.GetFloat("Hardship");
        InvokeRepeating("ExplodeSkill", 0, fltexplodeSkill);
    }

    public int intCD;
    public float fltexplodeSkill;
    public Vector2 vecEnemyAVel;
    public GameObject[] objEA;
    public GameObject[] gbjParticle;
    public float[] fltIncomingX;
    public float[] fltIncomingY;

    public void ExplodeSkill()
    {
        for (int i = 0; i < intCD; i++)
        {
            Vector2 actEP = new Vector2(this.transform.position.x + fltIncomingX[i], this.transform.position.y + fltIncomingY[i]);
            GameObject actEA = Instantiate(objEA[i], actEP, this.transform.rotation);
            actEA.GetComponent<Rigidbody2D>().velocity = vecEnemyAVel;
        }
        for (int i = 0; i < gbjParticle.Length; i++)
        {
            gbjParticle[i].GetComponent<ParticleSystem>().Play();
        }
        this.GetComponent<SC_AudioManager>().PlayAudio(2, 0.25f);
    }
}
