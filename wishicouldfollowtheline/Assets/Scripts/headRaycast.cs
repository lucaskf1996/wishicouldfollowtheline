using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    private bool alreadySent;
    private GameObject lastHit;

    void Start()
    {
        alreadySent = false;
    }

    void Update(){
        RaycastHit interact;
        if(Input.GetMouseButtonDown(0)){
            // Debug.Log("teste");
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out interact, 1.5f)){
                // Debug.Log(interact.transform.gameObject.tag);
                if(interact.transform.gameObject.tag == "interactable"){
                    Destroy(GameObject.FindWithTag(interact.transform.gameObject.tag+"trap"));
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // RaycastHit lastHit;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f))
        {
            // Debug.Log(lastHit.tag);

            if(hit.transform.gameObject.tag == "interactable"){
                lastHit = hit.transform.gameObject ;
                alreadySent = true;
                hit.transform.SendMessage ("HitByRay");
            }
        }
        else{
            if(alreadySent){
                lastHit.transform.SendMessage ("NotHitByRay");
                alreadySent = false;
            }
        }
    }
}
