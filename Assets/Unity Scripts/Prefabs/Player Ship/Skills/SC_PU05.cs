using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PU05 : MonoBehaviour {

    // Memoria Privada.
    private Vector2[] actLPA;

    // Memoria Pública.
    public Material MaterialParticle;
    public Sprite SpritePlayer;
    public GameObject[] objPA;
    public GameObject[] gbjParticle;
    
    public void EnableSkill() {

        for (int i = 0; i < gbjParticle.Length; i++) {

            gbjParticle[i].GetComponent<ParticleSystemRenderer>().material = MaterialParticle;

        }

        GetComponent<SpriteRenderer>().sprite = SpritePlayer;

        InvokeRepeating("ExplodeSkill", 0, 0.15f);
        GetComponent<SC_PlayerShip>().StartSkill(50);
        GameObject.Find("SpawnManager").GetComponent<SC_Spawns>().SpawnRepeat(0, (0.4f / PlayerPrefs.GetFloat("Hardship")));
        GameObject.Find("bgdPurple").GetComponent<SC_Background>().IncomingVel = 2;

    }
    
    public void ExplodeSkill() {

        SC_Spawns Spawn = GameObject.Find("SpawnManager").GetComponent<SC_Spawns>();
        Spawn.Incoming += 0.2f;

        actLPA = new Vector2[] {

            new Vector2(transform.position.x, transform.position.y + 1.5f),
            new Vector2(transform.position.x - 0.47f, transform.position.y + 1.5f),
            new Vector2(transform.position.x + 0.47f, transform.position.y + 1.5f),
            new Vector2(transform.position.x - 0.82f, transform.position.y + 1.2f),
            new Vector2(transform.position.x + 0.82f, transform.position.y + 1.2f)

        };

        for (int i = 0; i < 5; i++) {

            GameObject actPA = Instantiate(objPA[i], actLPA[i], transform.rotation);
            actPA.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);

        }
    
        for (int i = 0; i < gbjParticle.Length; i++) {

            gbjParticle[i].GetComponent<ParticleSystem>().Play();

        }

        this.GetComponent<SC_AudioManager>().PlayAudio(0, 0.5f);

    }
}