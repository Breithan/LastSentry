using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_PanelAnim : MonoBehaviour {
    private Image Image;
    private float incoming;

    public bool Open { get; set; }
    public float Incoming { get; set; }

	private void Start ()
    {
        Image = this.GetComponent<Image>();

        if (Open)
        {
            incoming = 0;
            Incoming = 0.05f;
        }

        else
        {
            incoming = 1;
            Incoming = -0.05f;
        }
    }
	
	private void Update ()
    {
        if (Open)
        {
            OpenPanel();
        }

        else
        {
            ClosePanel();
        }
    }

    private void Run()
    {
        incoming += Incoming;
        Image.color = new Color(1, 1, 1, incoming);
        foreach (Image i in GetComponentsInChildren<Image>())
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, incoming);
        }

        foreach (Text i in GetComponentsInChildren<Text>())
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, incoming);
        }
    }

    private void OpenPanel()
    {
        if (incoming < 1)
        {
            Run();
        }

        else
        {
            Destroy(this);
        }
    }

    private void ClosePanel()
    {
        if (incoming > 0)
        {
            Run();
        }

        else
        {
            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
