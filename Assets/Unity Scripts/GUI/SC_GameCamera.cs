using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_GameCamera : MonoBehaviour
{

    private GameObject activeSR;
    private GameObject activeFR;

    public GameObject starRandom;
    public GameObject flashRandom;
    public GameObject objGameUI;

    private void Stars()
    {
        activeSR = Instantiate(starRandom, new Vector3(Random.Range(-9, 9), transform.position.y + Random.Range(-2, 2), -5), transform.rotation);
        Destroy(activeSR, 3);
    }

    private void Flashes()
    {
        activeFR = Instantiate(flashRandom, new Vector3(Random.Range(-9, 9), transform.position.y - 9, -5), transform.rotation);
        activeFR.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10);
        Destroy(activeFR, 2);
    }

    void Start()
    {
        InvokeRepeating("Stars", 0, Random.Range(1, 2));
        InvokeRepeating("Flashes", 0, Random.Range(1, 2));
    }

    void Update()
    {
        if (objGameUI.GetComponent<SC_GameGUI>().Pause == true && objGameUI != null)
        {
            GetComponent<AudioSource>().UnPause();
        }
        else
        {
            GetComponent<AudioSource>().Pause();
        }
    }
}
