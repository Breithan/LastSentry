using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Boss2Shot : MonoBehaviour {

    void Start()
    {
        Discord /= PlayerPrefs.GetFloat("Hardship");
        InvokeRepeating("ExplodeSkill", 3, Discord / 2);
    }

    #region Propiedaes
    public GameObject gobMissilRed;
    public float Discord;
    #endregion

    public void ExplodeSkill()
    {
        GameObject activeM1 = Instantiate(gobMissilRed, new Vector2(this.transform.position.x - 0.9f, this.transform.position.y - 1.5f), this.transform.rotation);
        activeM1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -12);

        GameObject activeM2 = Instantiate(gobMissilRed, new Vector2(this.transform.position.x + 0.9f, this.transform.position.y - 1.5f), this.transform.rotation);
        activeM2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -12);

        this.GetComponent<AudioSource>().Play();
    }
}
