using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PU03 : MonoBehaviour
{
    // Memoria Privada.
    private Vector2[] actLPA;
    private int incoming;

    // Memoria Pública.
    public GameObject[] objPA;
    public GameObject[] gbjParticle;
    
    public void EnableSkill () {

        incoming = 1;
        InvokeRepeating("ExplodeSkill", 0, 0.25f);
        GetComponent<SC_PlayerShip>().StartSkill(35);
        GameObject.Find("SpawnManager").GetComponent<SC_Spawns>().SpawnRepeat(0, (0.6f / PlayerPrefs.GetFloat("Hardship")));
        GameObject.Find("bgdPurple").GetComponent<SC_Background>().IncomingVel = 2;

    }
    
    public void ExplodeSkill () {

        SC_Spawns Spawn = GameObject.Find("SpawnManager").GetComponent<SC_Spawns>();
        Spawn.Incoming += 0.6f;

        actLPA = new Vector2[] {

            new Vector2(transform.position.x, transform.position.y + 1.5f),
            new Vector2(transform.position.x - 0.47f, transform.position.y + 1.5f),
            new Vector2(transform.position.x + 0.47f, transform.position.y + 1.5f),
            new Vector2(transform.position.x - 0.82f, transform.position.y + 1.2f),
            new Vector2(transform.position.x + 0.82f, transform.position.y + 1.2f)

        };

        for (int i = 0; i < 3; i++) {

            GameObject actPA = Instantiate(objPA[i], actLPA[i], transform.rotation);
            actPA.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 17.5f);

        }

        for (int i = 0; i < 3; i++) {

            gbjParticle[i].GetComponent<ParticleSystem>().Play();

        }

        if (incoming > 1) {

            for (int i = 3; i < 5; i++) {

                GameObject actPA = Instantiate(objPA[i], actLPA[i], this.transform.rotation);
                actPA.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 17.5f);

            }

            for (int i = 3; i < 5; i++) {

                gbjParticle[i].GetComponent<ParticleSystem>().Play();

            }

        }

        incoming++;

        if (incoming > 2) {

            incoming = 1;

        }

        this.GetComponent<SC_AudioManager>().PlayAudio(0, 0.4f);
    }
}