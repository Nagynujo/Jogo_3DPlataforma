using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{   public GameObject mensagemUI; 
    public float tempoNaTela = 2f; 
    public GameObject InteractableObject;
    
    
    public void Interagir()
    {
       Destroy(gameObject); 
        
        MostrarMensagem();
    }

   public void MostrarMensagem()
    {
        
        if (mensagemUI == null) return;

        mensagemUI.SetActive(true);
        CancelInvoke(); 
        tempoNaTela = 2f;
       
        
    }

   public  void EsconderMensagem()
    {
        mensagemUI.SetActive(false);
    }


}
