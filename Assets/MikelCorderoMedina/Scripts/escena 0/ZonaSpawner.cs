using UnityEngine;

public class ZonaSpawner : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    public float distancia = 0.5f;
    public float separacion = 1.5f;

    void Start()
    {
        Camera cam = Camera.main;
        Vector3 basePos = cam.transform.position + cam.transform.forward * distancia;
        Vector3 derecha = cam.transform.right * separacion;

        Instantiate(portal1, basePos - derecha, Quaternion.identity);
        Instantiate(portal2, basePos + derecha, Quaternion.identity);
    }
}
