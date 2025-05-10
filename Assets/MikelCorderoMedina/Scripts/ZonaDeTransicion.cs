using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaDeTransicion : MonoBehaviour
{
    public int escenaDestino;
    public GameObject uiCanvas; // UI que se muestra al entrar

    void Start()
    {
        uiCanvas.SetActive(false); // Ocultamos la UI al principio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            uiCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            uiCanvas.SetActive(false);
        }
    }

    public void IrAEscena()
    {
        SceneManager.LoadScene(escenaDestino);
    }
}
