using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public float interactionRange = 5f;
    public GameObject player;

   /* void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactionRange))
        {
            if (hit.transform.gameObject.tag == "BuyableDoor" && player.GetComponent<PlayerPoints>().points >= hit.transform.gameObject.GetComponent<BuyableDoor>().doorPrice)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    player.GetComponent<PlayerPoints>().subtractPoints(hit.transform.gameObject.GetComponent<BuyableDoor>().doorPrice);
                    hit.transform.gameObject.GetComponent<BuyableDoor>().purchased = true;
                }
            }
        } 
    }*/
}