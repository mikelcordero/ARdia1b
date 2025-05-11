using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ZonaDeTransicion : MonoBehaviour
{
    public GameObject uiCanvas;
    public int escenaDestino = 1;

    public void IrAEscena()
    {
        // Detener el ARSession si existe
        ARSession arSession = FindObjectOfType<ARSession>();
        if (arSession != null)
        {
            arSession.Reset();
        }

        SceneManager.LoadScene(escenaDestino);
    }
}
