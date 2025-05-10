using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaDeTransicion : MonoBehaviour
{
    public int escenaDestino;
    public GameObject uiCanvas;

    void Start()
    {
        uiCanvas.SetActive(false);
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
        Debug.Log("Botón pulsado. Cambio de escena...");
        SceneManager.LoadScene(escenaDestino);
    }
}
