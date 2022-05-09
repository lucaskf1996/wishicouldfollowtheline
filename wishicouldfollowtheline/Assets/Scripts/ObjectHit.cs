using UnityEngine;

public class ObjectHit : MonoBehaviour {

    public Material material1, material2;

    void HitByRay () {
        // Debug.Log ("I was hit by a Ray");
        gameObject.GetComponent<Renderer>().material = material1;
    }

    void NotHitByRay () {
        // Debug.Log ("I was not hit by a Ray");
        gameObject.GetComponent<Renderer>().material = material2;
    }
}