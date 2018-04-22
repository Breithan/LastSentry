using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_PlayerShip : MonoBehaviour
{
    // Memoria Privada.
    private GameObject activeEM;
    private GameObject activeSH;
    private Slider healthBar;
    private Slider shieldBar;
    private Text scoreText;
    private float incoming;
    // Memoria Pública.
    public float incomingDamageH;
    public float incomingRestoreH;
    public float incomingDamageS;
    public float incomingRestoreS;
    public float healPoints;
    public float shieldPoints;
    public float scorePoints;
    public GameObject shieldActive;
    public GameObject explotion;
    public GameObject gameOver;
    public GameObject gameScore;
    public GameObject plasmaShock;
    public GameObject plasmaHeal;
    public GameObject plasmaShield;
    public Image[] img_Bars; // Barras UI.
    
    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("PHB").GetComponent<Slider>();
        shieldBar = GameObject.FindGameObjectWithTag("PPB").GetComponent<Slider>();
        scoreText = GameObject.FindGameObjectWithTag("SPT").GetComponent<Text>();
        healPoints *= PlayerPrefs.GetFloat("Hardship");
        shieldPoints *= PlayerPrefs.GetFloat("Hardship");
        healthBar.maxValue = healPoints;
        shieldBar.maxValue = shieldPoints;
    }

    private void Update()
    {
        if (Time.timeScale != 0) scorePoints += (1 * PlayerPrefs.GetFloat("Hardship"));
        scoreText.text = "Puntaje: " + (int)scorePoints;
        ShieldManager();
        HealtManager();
        if (healPoints <= 1)
        {
            gameOver.SetActive(true);
            gameScore.GetComponent<Text>().text = "Tu Puntaje: " + scorePoints;

            activeEM = Instantiate(explotion, this.transform.position, this.transform.rotation);
            this.GetComponent<SC_AudioManager>().PlayAudio(3, 1, GameObject.Find("Game Camera"));
            Destroy(activeEM, 2);
            Destroy(this.gameObject);
        }
        if (activeSH != null) activeSH.transform.position = this.transform.position;
    }

    public void PlayerScore(float value)
    {
        var oleada = this.GetComponent<SC_ManagerSK>().PlayerSkill;
        scorePoints += (int)value * oleada * PlayerPrefs.GetFloat("Hardship");
    }

    public void StartSkill(float NewHealt)
    {
        NewHealt *= PlayerPrefs.GetFloat("Hardship");
        Slider actHealthBar = GameObject.FindGameObjectWithTag("PHB").GetComponent<Slider>();
        Slider actShieldBar = GameObject.FindGameObjectWithTag("PPB").GetComponent<Slider>();
        healPoints += 5;
        shieldPoints += 5;
        actHealthBar.maxValue = NewHealt;
        actShieldBar.maxValue = NewHealt * 2;
        incomingRestoreH = NewHealt;
        incomingRestoreS = NewHealt * 2;
    }

    private void ShieldManager()
    {
        incoming = incomingDamageS * 0.6666666667f;
        if (shieldPoints < 0) shieldPoints = 0;
        if (incomingDamageS > 1)
        {
            shieldPoints -= Time.deltaTime * incoming;
            incomingDamageS -= Time.deltaTime * incoming;
            img_Bars[1].GetComponent<SC_HealAnim>().GoAnimation();
        }

        else if (incomingDamageS < 1) incomingDamageS = 0;
        
        incoming = incomingRestoreS * 0.6666666667f;
        if (incomingRestoreS > 0 & shieldPoints <= (shieldBar.maxValue))
        {
            shieldPoints += Time.deltaTime * incoming;
            incomingRestoreS -= Time.deltaTime * incoming;
        }
        else incomingRestoreS = 0;

        shieldBar.value = shieldPoints;
    }
    
    private void HealtManager()
    {
        incoming = incomingDamageH * 0.6666666667f;
        if (incomingDamageH > 1)
        {
            healPoints -= Time.deltaTime * incoming;
            incomingDamageH -= Time.deltaTime * incoming;
            img_Bars[0].GetComponent<SC_HealAnim>().GoAnimation();
        }

        else if (incomingDamageH < 1) incomingDamageH = 0;

        incoming = incomingRestoreH * 0.6666666667f;
        if (incomingRestoreH > 0 & healPoints <= (healthBar.maxValue))
        {
            healPoints += Time.deltaTime * incoming;
            incomingRestoreH -= Time.deltaTime * incoming;
        }
        else incomingRestoreH = 0;

        healthBar.value = healPoints;
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        // Colisión con un Meteoro.
        if (coll.gameObject.tag == "Meteor")
        {
            if (shieldPoints > 0)
            {
                incomingDamageS += coll.gameObject.GetComponent<SC_Meteor>().Damage;
                if (activeSH != null) Destroy(activeSH);
                activeSH = Instantiate(shieldActive, transform.position, transform.rotation);
                Destroy(activeSH, 1);
            }
            else incomingDamageH += coll.gameObject.GetComponent<SC_Meteor>().Damage;
            coll.gameObject.GetComponent<SC_Meteor>().healPoints = 0;
        }
        // Colisión con un Enemigo.
        if (coll.gameObject.tag == "Enemy")
        {
            if (shieldPoints > 0)
            {
                incomingDamageS += coll.gameObject.GetComponent<SC_Enemy_Ships>().Damage;
                if (activeSH != null) Destroy(activeSH);
                activeSH = Instantiate(shieldActive, transform.position, transform.rotation);
                Destroy(activeSH, 1);
            }
            else incomingDamageH += coll.gameObject.GetComponent<SC_Enemy_Ships>().Damage;
            coll.gameObject.GetComponent<SC_Enemy_Ships>().healPoints = 0;
        }
        // Colisión con un ataque del elemigo.
        if (coll.gameObject.tag == "Enemy Laser")
        {
            if (shieldPoints > 0)
            {
                incomingDamageS += coll.gameObject.GetComponent<SC_LaserEnemy>().Damage;
                if (activeSH != null) Destroy(activeSH);
                activeSH = Instantiate(shieldActive, transform.position, transform.rotation);
                Destroy(activeSH, 1);
            }
            else incomingDamageH += coll.gameObject.GetComponent<SC_LaserEnemy>().Damage;

            Vector3 plasmaPosition = new Vector3(coll.transform.position.x, coll.transform.position.y, -14);
            Quaternion plasmaRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            GameObject plasma = Instantiate(plasmaShock, plasmaPosition, plasmaRotation);
            plasma.transform.SetParent(transform);
            Destroy(plasma, 1);
            
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Restore")
        {
            incomingRestoreH += healthBar.maxValue * 0.2f * PlayerPrefs.GetFloat("Hardship");
            incomingDamageS = 0;
            incomingDamageH = 0;
            plasmaHeal.GetComponent<ParticleSystem>().Play();
            this.GetComponent<SC_AudioManager>().PlayAudio(2);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Shield")
        {
            plasmaShield.GetComponent<ParticleSystem>().Play();
            incomingDamageS = 0;
            incomingDamageH = 0;
            incomingRestoreS += shieldBar.maxValue * 0.2f * PlayerPrefs.GetFloat("Hardship");
            this.GetComponent<SC_AudioManager>().PlayAudio(1);
            Destroy(coll.gameObject);
        }
    }
}