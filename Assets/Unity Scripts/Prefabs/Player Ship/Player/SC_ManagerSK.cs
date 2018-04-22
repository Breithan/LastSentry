using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_ManagerSK : MonoBehaviour
{
    // Variables Públicas.
    public GameObject objGameOver;
    public GameObject objGameUI;
    public GameObject gameScore;
    public GameObject plasmaBurst;
    public float[] fltMetVel;

    // Devuelve la Skill actual del jugador.
    public int PlayerSkill { get; private set; }

    private void Start() {PlayerSkill = 0; PowerUp();}

    // Controlador de Skill. Actualiza las Skill y añade el Power Up.
    public void PowerUp()
    {
        foreach (GameObject meteor in GameObject.FindGameObjectsWithTag("Meteor"))
        {
            meteor.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -fltMetVel[PlayerSkill]);
        }

        foreach (GameObject meteor in GameObject.FindGameObjectsWithTag("BackMeteor"))
        {
            meteor.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -fltMetVel[PlayerSkill]);
        }

        PlayerSkill++;
        if (PlayerSkill != 1) 
        {
            plasmaBurst.GetComponent<ParticleSystem>().Play();
        }
        if (PlayerSkill == 1)
        {
            GetComponent<SC_PU01>().enabled = true;
            GetComponent<SC_PU01>().EnableSkill();

        }
        else if (PlayerSkill == 2)
        {
            GetComponent<SC_PU01>().CancelInvoke();
            Destroy(GetComponent<SC_PU01>());

            GetComponent<SC_PU02>().enabled = true;
            GetComponent<SC_PU02>().EnableSkill();
        }
        else if (PlayerSkill == 3)
        {
            GetComponent<SC_PU02>().CancelInvoke();
            Destroy(GetComponent<SC_PU02>());

            GetComponent<SC_PU03>().enabled = true;
            GetComponent<SC_PU03>().EnableSkill();
        }
        else if (PlayerSkill == 4)
        {
            GetComponent<SC_PU03>().CancelInvoke();
            Destroy(GetComponent<SC_PU03>());

            GetComponent<SC_PU04>().enabled = true;
            GetComponent<SC_PU04>().EnableSkill();
        }
        else if (PlayerSkill == 5)
        {
            GetComponent<SC_PU04>().CancelInvoke();
            Destroy(GetComponent<SC_PU04>());

            GetComponent<SC_PU05>().enabled = true;
            GetComponent<SC_PU05>().EnableSkill();

            ParticleSystem ps = plasmaBurst.GetComponent<ParticleSystem>();
            var main = ps.main;
            main.loop = true;
        }

        else if (PlayerSkill == 6)
        {
            GetComponent<SC_PU05>().CancelInvoke();
            Destroy(GetComponent<SC_PU05>());
            gameObject.AddComponent<SC_FinalGame>();
            objGameOver.SetActive(true);
            var scorePoints = GetComponent<SC_PlayerShip>().scorePoints;
            gameScore.GetComponent<Text>().text = "Tu Puntaje: " + scorePoints;
            if (objGameUI != null) objGameUI.SetActive(false);
            Destroy(GetComponent<SC_ManagerMV>());
            Destroy(gameObject, 1);
        }
    }

    // Método de detección de colisiones.
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Power Up")
        {
            SC_Spawns Spawn = GameObject.Find("SpawnManager").GetComponent<SC_Spawns>();
            Spawn.BossActive = true;
            Spawn.Oleada++;
            Spawn.Progress = 0;
            Spawn.ProgressBar.gameObject.SetActive(true);
            PowerUp();
            Destroy(coll.gameObject);
        }
    }
}
