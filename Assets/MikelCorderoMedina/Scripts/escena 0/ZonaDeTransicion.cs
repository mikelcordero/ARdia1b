using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaDeTransicion : MonoBehaviour
{
    public GameObject uiCanvas;
    public int escenaDestino = 1;

    private void Start()
    {
        uiCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Cámara ha entrado en la zona");
            uiCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Cámara ha salido de la zona");
            uiCanvas.SetActive(false);
        }
    }

    public void IrAEscena()
    {
        SceneManager.LoadScene(escenaDestino);
    }
}
