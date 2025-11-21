using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject InteractableObject;
    public void Interagir()
    {
       Debug.Log("Interagiu e destruiu o objeto: ");

        Destroy(gameObject); 
        
        
    }
}
