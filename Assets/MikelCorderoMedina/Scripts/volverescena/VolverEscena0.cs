using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverEscena0 : MonoBehaviour
{
    public void VolverAlMenu()
    {
        SceneManager.LoadScene(0); // Asegúrate de que Escena 0 esté en el Build Settings
    }
}
