using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MouseMovement : MonoBehaviour
{
   public float mouseSensetivity = 100f;

   private float xRotation = 0f;
   private float yRotation = 0f;

   public float topClamp = -90f;
   public float bottomClamp = 90f;

    void Start()
    {   
        // Travando mouse no centro da tela
        Cursor.lockState =CursorLockMode.Locked;
    
    }

   
    void Update()
    {
        // Inputs de movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") *mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") *mouseSensetivity * Time.deltaTime;

        // Olhando para cima e para baixo
        xRotation -= mouseY;

        // Bloqueando rotação do player no eixo x  em 90 graus
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // Rodando no eixo y (olhando direita e esquerda)
        yRotation += mouseX;

        //Aplicando rotação no transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);







    }
}
