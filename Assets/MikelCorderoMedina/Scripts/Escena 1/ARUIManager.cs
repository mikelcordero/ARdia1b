using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class ARUIManager : MonoBehaviour
{
    public TMP_Text planoTexto;
    public Button borrarButton;
    public TMP_Dropdown prefabDropdown;

    public ARPlaneManager planeManager;

    public GameObject[] prefabOpciones;
    private int prefabSeleccionado = 0;

    private GameObject instanciaActual; // ✅ Guardamos solo una instancia

    void Start()
    {
        // Eventos
        borrarButton.onClick.AddListener(BorrarInstancia);
        prefabDropdown.onValueChanged.AddListener(CambiarPrefabSeleccionado);

        // Rellenar combo si está vacío
        if (prefabDropdown.options.Count == 0)
        {
            prefabDropdown.ClearOptions();
            List<string> nombres = new List<string>();
            foreach (GameObject prefab in prefabOpciones)
            {
                nombres.Add(prefab.name);
            }
            prefabDropdown.AddOptions(nombres);
        }
    }

    void Update()
    {
        if (planeManager != null)
        {
            planoTexto.text = "Planos detectados: " + planeManager.trackables.count;
        }
    }

    public void InstanciarPrefab(Vector3 posicion)
    {
        // ✅ Si ya hay uno, lo eliminamos
        if (instanciaActual != null)
        {
            Destroy(instanciaActual);
        }

        // ✅ Instanciamos nuevo y lo guardamos como actual
        instanciaActual = Instantiate(prefabOpciones[prefabSeleccionado], posicion, Quaternion.identity);
    }

    void BorrarInstancia()
    {
        if (instanciaActual != null)
        {
            Destroy(instanciaActual);
            instanciaActual = null;
        }
    }

    void CambiarPrefabSeleccionado(int index)
    {
        prefabSeleccionado = index;
    }
}
