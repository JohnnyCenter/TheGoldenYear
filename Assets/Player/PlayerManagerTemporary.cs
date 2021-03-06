using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerTemporary : MonoBehaviour
{
    [SerializeField] Movement p_movement;
    [SerializeField] PlayerLook p_look;
    [SerializeField] PlayerRaycast p_raycast;

    public List<GameObject> objectsSeen = new List<GameObject>();
    [SerializeField] GameObject canvasText_interact;


    private void Update()
    {

        if (objectsSeen.Count > 0)
        {

            canvasText_interact.SetActive(true);
        } else
        {

            canvasText_interact.SetActive(false);
        }
    }

    public void DisablePlayerAll()
    {
        p_look.isDisabled = true;
        p_raycast.isDisabled = true;
        p_movement.enabled = false;
    }

    public void EnablePlayerAll()
    {
        p_look.isDisabled = false;
        p_raycast.isDisabled = false;
        p_movement.enabled = true;
    }
}
