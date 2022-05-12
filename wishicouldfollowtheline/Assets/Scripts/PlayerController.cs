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
   float _gravidade = -9.8f;

   CharacterController characterController;
   GameManager gm;
   
   void Start()
   {
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        characterController = GetComponent<CharacterController>();
        gm = GameManager.GetInstance();
    }

   void Update()
   {
       if(gm.allowMovement){
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            float y = 0f;

            if(Input.GetKeyDown(KeyCode.LeftShift)){
                _baseSpeed = _baseSpeed*2f;
            }
            if(Input.GetKeyUp(KeyCode.LeftShift)){
                _baseSpeed = 6.0f;
            }

            // if(!characterController.isGrounded){
            //     y = -_gravidade * Time.deltaTime;
            // }

            if (characterController.isGrounded && y < 0)
            {
                y = 0f;
            }

            // Changes the height position of the player..
            if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                y += 50f;
            }

            direction = transform.right * x * _baseSpeed + transform.up * 1 + transform.forward * z * _baseSpeed;

            y += _gravidade * Time.deltaTime;
            direction.y = y;
            characterController.Move(direction * Time.deltaTime);

            //Tratando movimentação do mouse
            float mouse_dX = Input.GetAxis("Mouse X");
            float mouse_dY = -Input.GetAxis("Mouse Y");
                
            //Tratando a rotação da câmera
            cameraRotation += mouse_dY;
            cameraRotation = Mathf.Clamp(cameraRotation, -75.0f, 75.0f);
            transform.Rotate(Vector3.up, mouse_dX);
            playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
       } else {
           Cursor.lockState = CursorLockMode.None;
       }
   }
}