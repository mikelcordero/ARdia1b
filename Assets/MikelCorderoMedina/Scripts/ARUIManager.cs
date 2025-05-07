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
    private List<GameObject> instancias = new List<GameObject>();

    void Start()
    {
        // Eventos
        borrarButton.onClick.AddListener(BorrarInstancias);
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
        GameObject nuevo = Instantiate(prefabOpciones[prefabSeleccionado], posicion, Quaternion.identity);
        instancias.Add(nuevo);
    }

    void BorrarInstancias()
    {
        foreach (GameObject obj in instancias)
        {
            Destroy(obj);
        }
        instancias.Clear();
    }

    void CambiarPrefabSeleccionado(int index)
    {
        prefabSeleccionado = index;
    }
}
