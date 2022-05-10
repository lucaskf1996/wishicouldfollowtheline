using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    CursorLockMode lockMode;
    public Vector3 direction;

    void Awake () {
    lockMode = CursorLockMode.Locked;
    Cursor.lockState = lockMode;
    direction = Vector3.zero;
    }

   //Referência usada para a câmera filha do jogador
   GameObject playerCamera;
   //Utilizada para poder travar a rotação no angulo que quisermos.
   float cameraRotation;
   float _baseSpeed = 6.0f;
   float _gravidade = 9.8f;

   CharacterController characterController;
   
   void Start()
   {
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        characterController = GetComponent<CharacterController>();
    }

   void Update()
   {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            _baseSpeed = _baseSpeed*1.5f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            _baseSpeed = 6.0f;
        }

        float y = 0;
        if(!characterController.isGrounded){
            y = -_gravidade;
        }

        //Tratando movimentação do mouse
        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = -Input.GetAxis("Mouse Y");
            
        //Tratando a rotação da câmera
        cameraRotation += mouse_dY;
        cameraRotation = Mathf.Clamp(cameraRotation, -75.0f, 75.0f);
        direction = transform.right * x + transform.up * y + transform.forward * z;
        characterController.Move(direction * _baseSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, mouse_dX);


        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);    
   }
}