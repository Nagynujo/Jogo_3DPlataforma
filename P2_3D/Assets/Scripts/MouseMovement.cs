using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MouseMovement : MonoBehaviour
{
    public GameObject mensagemUI; 
    public float tempoNaTela = 2f;

   public float mouseSensetivity = 100f;

   private float xRotation = 0f;
   private float yRotation = 0f;

   public float topClamp = -90f;
   public float bottomClamp = 90f;
     
    public Camera cam;
    public float distanciaInteracao = 3f;
    public KeyCode teclaInteragir = KeyCode.E;
    void Start()
    {   
        // Travando mouse no centro da tela
        Cursor.lockState =CursorLockMode.Locked;
    
    }

   
    void Update()
    {

        
        float mouseX = Input.GetAxis("Mouse X") *mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") *mouseSensetivity * Time.deltaTime;


        xRotation -= mouseY;

        
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        
        yRotation += mouseX;

        
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    
        if (Input.GetKeyDown(KeyCode.E))
        {
          Interact();
          
        }
       

        
        
        

    }
    
    
    void Interact()
    {
        RaycastHit hit;

        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanciaInteracao))
        {
            
            Interactable interagivel = hit.collider.GetComponent<Interactable>();

            if (interagivel != null)
            {
                interagivel.Interagir();
            }
        }
        
    
    }
    public void MostrarMensagem()
    {
        
        
        if (mensagemUI == null) return;

        mensagemUI.SetActive(true);
        CancelInvoke(); 
        
        
       
        
    }

   public  void EsconderMensagem()
    {
        mensagemUI.SetActive(false);
    }
    
}