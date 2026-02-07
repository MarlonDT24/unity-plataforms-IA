using UnityEngine;
using UnityEngine.AI;

public class EnemigoIA : MonoBehaviour
{
    public Transform objetivo; // A quién persigue
    public float distanciaDeteccion = 20f; // Distancia de visión
    
    private NavMeshAgent agente;

    void Start()
    {
        // Buscamos el componente de navegación en este mismo objeto
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Calculamos la distancia entre el enemigo y el jugador
        float distancia = Vector3.Distance(transform.position, objetivo.position);

        // Si el jugador está cerca (dentro del rango), vamos a por él
        if (distancia < distanciaDeteccion)
        {
            agente.SetDestination(objetivo.position);
        }
    }
}
