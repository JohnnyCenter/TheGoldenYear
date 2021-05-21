using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] float raycastLength = 5f;

    [SerializeField] LayerMask interactableMask;
    [SerializeField] PlayerManagerTemporary playerManager;

    [SerializeField]
    bool seesDoor = false;
    bool seesBed = false;
    public bool isDisabled = false;

    void Update()
    {
        if (!isDisabled)
        {
            #region raycasts

            //IF RAYCAST IS EMPTY (no layermask)
            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, raycastLength, interactableMask))
            {
                if (!playerManager.objectsSeen.Contains(hit.collider.gameObject))
                {
                    playerManager.objectsSeen.Add(hit.collider.gameObject);
                }

                if(hit.collider.tag == "Bed")
                {

                    seesBed = true;
                }   
                
                if(hit.collider.tag == "Door")
                {

                    seesDoor = true;
                }

            } else
            {
                seesDoor = false;
                seesBed = false;
                playerManager.objectsSeen.Clear();
            }

            #endregion
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.position, cam.forward * raycastLength);
    }

    public void InteractPressed()
    {
        if (!isDisabled)
        {
            if (seesDoor)
            {
                StartCoroutine(DoorAnim());
            }            
            
            if (seesBed)
            {
                StartCoroutine(BedAnim());
            }

        }
        
    }

    #region bed things
    private IEnumerator BedAnim()
    {
        playerManager.DisablePlayerAll();
        GoToBed();

        //HVOR MANGE SEKUNDER VARER ANIM;
        yield return new WaitForSeconds(2f);

        //FADE TO BLACK

        //yield return new WaitForSeconds(2f);

        EndDay();

        playerManager.EnablePlayerAll();

        yield return null;
    }

    void GoToBed()
    {
        Debug.Log("GO TO BED NOW");
        //PLAY ANIM
        //PLAY SOUND EFFECT
    }

    void EndDay()
    {
        //SWITCH SCENE
        //PROGRESSION COUNTER
    }

    
    #endregion

    #region door things
    //HER KAN DU KALLE PÅ FUNKSJONEN FOR Å ÅPNE DØRA OSV
    void OpenDoor()
    {
        Debug.Log("OPEN DOOR");
        //PLAY ANIM
        //PLAY SOUND EFFECT
    }

    private IEnumerator DoorAnim()
    {
        playerManager.DisablePlayerAll();
        OpenDoor();

        //HVOR MANGE SEKUNDER VARER ANIM;
        yield return new WaitForSeconds(2f);

        playerManager.EnablePlayerAll();

        yield return null;
    }
    #endregion
}
