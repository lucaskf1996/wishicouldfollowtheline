using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collided){
        Debug.Log(collided.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
