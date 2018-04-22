using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_ManagerMV : MonoBehaviour
{
    #region //Stock Memory//
    // Memoria Pública.
    public Camera cmrCamera;
    public GameObject Obj_background;
    #endregion
    #region //Constructor//
    /// <summary>
    /// Método de actualización por frame.
    /// </summary>
    private void Update()
    {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = Vector3.MoveTowards(playerPosition, targetPosition, Time.deltaTime * 75);
        Vector3 cameraPosition = new Vector3(transform.position.x / 6, 0, -15);
        cmrCamera.transform.position = cameraPosition;
        Vector3 backgroundPosition = new Vector3(transform.position.x / 12, Obj_background.transform.position.y, 15);
        Obj_background.transform.position = backgroundPosition;

        float limitPlayerX = Mathf.Clamp(transform.position.x, -12, 12);
        float limitPlayerY = Mathf.Clamp(transform.position.y, -5, 5);
        transform.position = new Vector3(limitPlayerX, limitPlayerY, 0);
    }
    #endregion
}