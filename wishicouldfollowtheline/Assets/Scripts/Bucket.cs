using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public GameObject promptCanvas;

    void HitByRay () {

        promptCanvas.SetActive(true);
    }

    void NotHitByRay () {
        promptCanvas.SetActive(false);
    }
}
