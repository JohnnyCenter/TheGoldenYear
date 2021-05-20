using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] float raycastLength = 5f;
    [SerializeField] GameObject canvasText_interact;
    [SerializeField] LayerMask doorMask;

    bool seesDoor = false;

    void Update()
    {
        #region sees door
        RaycastHit hit_door;
        if(Physics.Raycast(cam.position, cam.forward, out hit_door, raycastLength, doorMask))
        {
            canvasText_interact.SetActive(true);
            seesDoor = true;
        }
        else
        {
            canvasText_interact.SetActive(false);
            seesDoor = false;
        }
        #endregion

        Debug.Log("SEES DOOR: " + seesDoor);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.position, cam.forward * raycastLength);
    }

    public void InteractPressed()
    {
        if (seesDoor)
        {
            OpenDoor();
        }
    }


    //HER KAN DU KALLE PÅ FUNKSJONEN FOR Å ÅPNE DØRA OSV
    public void OpenDoor()
    {
        Debug.Log("OPEN DOOR");
    }
}
