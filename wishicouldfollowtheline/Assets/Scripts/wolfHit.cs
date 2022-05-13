using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfHit : MonoBehaviour
{
    void Clicked(){
        gameObject.transform.Rotate(0f,0f,90f, Space.Self);
        gameObject.transform.position = new Vector3(0f,0f,0.4f)+gameObject.transform.position;
    }
}
