using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_LaserPlayer : MonoBehaviour {

    #region //Stock Memory//
    // Memoria Pública.
    public float damage;
    /// <summary>
    /// Establece el daño del ataque.
    /// </summary>
    public float Damage { get { return damage; } set { damage = value; } }
    #endregion
    #region //Constructor//
    /// <summary>
    /// Constructor MonoBehaviour.
    /// </summary>
    private void Start()
    {
        damage *= PlayerPrefs.GetFloat("Hardship");
    }
    #endregion
}
