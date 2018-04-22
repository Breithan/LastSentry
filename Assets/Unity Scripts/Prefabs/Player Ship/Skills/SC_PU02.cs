using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PU02 : MonoBehaviour
{
    // Memoria Privada.
    private Vector2[] actLPA;
    // Memoria Pública.
    public GameObject[] objPA;
    public GameObject[] gbjParticle;

    // Inicia la ejecución de los ataques.
    public void EnableSkill()
    {
        InvokeRepeating("ExplodeSkill", 0, 0.3f);
        GetComponent<SC_PlayerShip>().StartSkill(15);
        GameObject.Find("SpawnManager").GetComponent<SC_Spawns>().SpawnRepeat(0, (0.8f / PlayerPrefs.GetFloat("Hardship")));
        GameObject.Find("bgdPurple").GetComponent<SC_Background>().IncomingVel = 3;
    }

    // Ejecuta el Ataque.
    public void ExplodeSkill()
    {
        SC_Spawns Spawn = GameObject.Find("SpawnManager").GetComponent<SC_Spawns>();
        Spawn.Incoming += 0.8f;
        actLPA = new Vector2[]
        {
            new Vector2(transform.position.x, transform.position.y + 1.5f),
            new Vector2(transform.position.x - 0.47f, transform.position.y + 1.5f),
            new Vector2(transform.position.x + 0.47f, transform.position.y + 1.5f)
        };
        for (int i = 0; i < objPA.Length; i++)
        {
            GameObject actPA = Instantiate(objPA[i], actLPA[i], this.transform.rotation);
            actPA.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
        }
        for (int i = 0; i < gbjParticle.Length; i++)
        {
            gbjParticle[i].GetComponent<ParticleSystem>().Play();
        }
        this.GetComponent<SC_AudioManager>().PlayAudio(0, 0.35f);
    }
}