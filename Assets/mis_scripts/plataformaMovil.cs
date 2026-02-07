using UnityEngine;

public class plataformaMovil : MonoBehaviour
{
    public Transform destino;
    public float velocidad = 3.0f;
    
    private Vector3 posInicial;
    private Vector3 posFinal;
    private bool yendoHaciaFinal = true;

    void Start()
    {
        // Guardamos las posiciones globales
        posInicial = transform.position;
        posFinal = destino.position;
    }

    void Update()
    {
        // 1. Calcular objetivo
        Vector3 objetivo = yendoHaciaFinal ? posFinal : posInicial;

        // 2. Moverse
        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        // 3. Comprobar llegada
        if (Vector3.Distance(transform.position, objetivo) < 0.01f)
        {
            yendoHaciaFinal = !yendoHaciaFinal;
        }
    }

    // LÓGICA DE EMPARENTAMIENTO
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("JUGADOR DENTRO - PADRE ASIGNADO");
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("JUGADOR FUERA - PADRE QUITADO");
            other.transform.parent = null;
        }
    }
}
