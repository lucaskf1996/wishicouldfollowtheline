using UnityEngine;

public class ParentHit : MonoBehaviour {

    // private GameObject[] children;
    // public Material material1, material2;

    void Start() {
        // children = transform.allChildren();
    }

    void HitByRay () {
        // Debug.Log ("I was hit by a Ray");
        foreach (Transform child in transform){
            if(child.tag == "outlineChild"){
                child.SendMessage ("HitByRay");
            }
        }
    }

    void NotHitByRay () {
        // Debug.Log ("I was not hit by a Ray");
        foreach (Transform child in transform){
            if(child.tag == "outlineChild"){
                child.SendMessage ("NotHitByRay");
            }
        }
    }
}