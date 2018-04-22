using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_LaserEnemy : MonoBehaviour {

    public float damage;

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    private void Start()
    {
        damage *= PlayerPrefs.GetFloat("Hardship");
    }
}
