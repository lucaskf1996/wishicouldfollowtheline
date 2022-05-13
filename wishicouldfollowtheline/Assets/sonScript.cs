using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonScript : MonoBehaviour
{

    public GameObject Player;
    Animator anim;
    public float speed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        // transform.LookAt(Camera.main.transform, Vector3.up);
        Vector3 estaPosicao = Player.transform.position - transform.position; //Comando para obter a posição do objeto em relação ao Player
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (estaPosicao), 3f * Time.deltaTime); //Comando para executar o giro na direção do objeto
        transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0); //Comando para travar os eixos X e Z, mantendo apenas o Y
        if(dist>3f){
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            anim.SetInteger("legs",1);
        }
        else{
            anim.SetInteger("legs",5);
        }

    }
}
