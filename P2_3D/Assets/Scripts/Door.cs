using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    public string cena = "Fase2";

    public override void Interagir()
    {
        Debug.Log("Entrou na porta!");
        SceneManager.LoadScene(cena);
    }
}
