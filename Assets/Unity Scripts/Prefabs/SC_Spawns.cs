using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Spawns : MonoBehaviour
{
    public bool BossActive { set; get; }
    public int intOleada;
    public float intProgress;
    public float incomingPro;
    public Slider sldProgressBar;
    public Slider sldBossBar;
    public Text txtOleada;
    public GameObject[] meteorMRandom;
    public GameObject[] meteorGRandom;
    public GameObject[] enemyRandom;
    public GameObject[] itemRandom;
    public GameObject[] Bosses;
    public Vector3[] vecBossPositions;

    public Slider BossBar { get { return sldBossBar; } }

    public Slider ProgressBar {
        get { return sldProgressBar; }
        set { sldProgressBar = value; }
    }

    public float Incoming {
        get { return incomingPro; }
        set { incomingPro = value; }
    }

    public float Progress {
        get { return intProgress; }
        set { intProgress = value; }
    }

    public int Oleada {
        set { intOleada = value; }
        get { return intOleada; }
    }

    private void Update() {
        txtOleada.text = "Oleada #" + intOleada;

        if (incomingPro > 0) {
            float incoming = incomingPro * 0.6666666667f;
            intProgress += incoming * Time.deltaTime;
            incomingPro -= incoming * Time.deltaTime;
        }
        else {
            incomingPro = 0;
        }

        if (intProgress > 100) {
            intProgress = 100;
        }

        if (sldProgressBar != null) {
            sldProgressBar.value = intProgress;
            sldProgressBar.GetComponentInChildren<Text>().text = "Progreso: " + (int)intProgress + "%";
            if (sldProgressBar.value == 100 && BossActive && intOleada <= 5) {
                CancelInvoke();
                InvokeRepeating("ItemRandom", 5, 10);
                InvokeRepeating("MeteorRandom", 0, 0.9f - ((((5 * Oleada) / 100)) / PlayerPrefs.GetFloat("Hardship")));
                sldProgressBar.gameObject.SetActive(false);
                Instantiate(Bosses[intOleada - 1], vecBossPositions[intOleada - 1], this.transform.rotation);
                BossActive = false;
            }
        }
    }

    private void Start() { BossActive = true; }

    public void SpawnRepeat(float time, float timeRepeat) {
        InvokeRepeating("MeteorRandom", time, timeRepeat);
        InvokeRepeating("EnemyRandom", time , timeRepeat * 2.5f);
        InvokeRepeating("ItemRandom", time, timeRepeat * 40);
    }

    public void MeteorRandom() {
        GameObject[][] meteors = { meteorMRandom, meteorGRandom} ;
        GameObject[] meteorR = {null, null};
        Vector3 meteorPos;
        int miniOleada;

        if (intOleada <= 5) {
            miniOleada = 0;
        }
        else {
            miniOleada = 1;
        }

        for (int i = 0; i < 2; i++) {
            meteorPos = new Vector2(Random.Range(-12, 12), transform.position.y + Random.Range(0, 3.0f));
            float randomSize = Random.Range(0.7f, 1);
            meteorR[i] = Instantiate(meteors[i][intOleada + miniOleada - 1], meteorPos, transform.rotation);
            meteorR[i].transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            meteorR[i].GetComponent<SC_Meteor>().Size(randomSize);
        }

        backMeteor();
    }

    public void EnemyRandom() {
        Vector3 enemyPos = new Vector2(Random.Range(-12f, 12), this.transform.position.y);
        Instantiate(enemyRandom[intOleada - 1], enemyPos, this.transform.rotation);
    }

    public void ItemRandom() {
        Vector3 itemPos = new Vector2(Random.Range(-12, 12), this.transform.position.y);
        Instantiate(itemRandom[Random.Range(0, 2)], itemPos, this.transform.rotation);
    }

    private void backMeteor() {
        for (int i = 0; i < 3; i++) {
            float randomSize = Random.Range(0.2f, 0.5f);
            Vector3 meteorPos = new Vector3(Random.Range(-12, 12), transform.position.y + Random.Range(-2,2), 4);
            GameObject meteor = Instantiate(meteorMRandom[intOleada - 1], meteorPos, this.transform.rotation);
            meteor.tag = "BackMeteor";
            meteor.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            meteor.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, randomSize);
            meteor.AddComponent<SC_BackMeteor>();
            Destroy(meteor.GetComponent<SC_Meteor>());
        }
    }
}
