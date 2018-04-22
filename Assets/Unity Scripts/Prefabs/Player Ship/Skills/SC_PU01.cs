using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PU01 : MonoBehaviour
{
    // Memoria Privada.
    private GameObject gbjParA;
    // Memoria Pública.
    public GameObject playerLaser;
	public GameObject[] gbjParticle;

    // Inicia la ejecución de los ataques.
    public void EnableSkill()
    {
        InvokeRepeating("ExplodeSkill", 1, 0.3f);
        GameObject.Find("SpawnManager").GetComponent<SC_Spawns>().SpawnRepeat(0, (0.9f / PlayerPrefs.GetFloat("Hardship")));
        GameObject.Find("bgdPurple").GetComponent<SC_Background>().IncomingVel = 4;
    }

    // Ejecuta el Ataque.
    public void ExplodeSkill()
    {
        SC_Spawns Spawn = GameObject.Find("SpawnManager").GetComponent<SC_Spawns>();
        Spawn.Incoming += 1;
        Vector2 actLPA = new Vector2(transform.position.x, transform.position.y + 1);
        GameObject actPA = Instantiate(playerLaser, actLPA, transform.rotation);
        actPA.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
        for (int i = 0; i < gbjParticle.Length; i++)
        {
            gbjParticle[i].GetComponent<ParticleSystem>().Play();
        }
        this.GetComponent<SC_AudioManager>().PlayAudio(0, 0.3f);
    }
}