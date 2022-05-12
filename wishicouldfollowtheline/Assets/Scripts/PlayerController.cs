using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    CursorLockMode lockMode;
    public Vector3 direction;
    public GameObject pauseUI;
    //Referência usada para a câmera filha do jogador
    GameObject playerCamera;
    //Utilizada para poder travar a rotação no angulo que quisermos.
    float cameraRotation;
    float _baseSpeed = 6.0f;
    float _gravidade = -9.8f;
    bool locked = false;
    float mouse_dX;
    float mouse_dY;

   CharacterController characterController;
   GameManager gm;
   
    void Awake () {
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
        direction = Vector3.zero;
    }
   
   void Start()
   {
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        characterController = GetComponent<CharacterController>();
        gm = GameManager.GetInstance();
    }

    void lockMouse(){
        locked = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void unlockMouse(){
        locked = false;
        Cursor.lockState = CursorLockMode.Locked;
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

            direction = transform.right * x * _baseSpeed + transform.up * 1 + transform.forward * z * _baseSpeed;

            y += _gravidade * Time.deltaTime;
            direction.y = y;
            characterController.Move(direction * Time.deltaTime);

            //Tratando movimentação do mouse
            if(locked){
                mouse_dX = 0;
                mouse_dY = 0;
            }
            else{
                mouse_dX = Input.GetAxis("Mouse X");
                mouse_dY = -Input.GetAxis("Mouse Y");
            }
            
                
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