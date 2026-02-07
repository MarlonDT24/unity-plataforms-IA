using UnityEngine;
using UnityEngine.AI;

public class ZonaSegura : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Solo actuamos si entra el Jugador
        if (other.CompareTag("Player"))
        {
            // 1. Buscamos a todos los enemigos para que tengan nuestro script
            EnemigoIA[] listaDeMalos = FindObjectsOfType<EnemigoIA>();

            // 2. Revisamos uno por uno
            foreach (EnemigoIA enemigo in listaDeMalos)
            {
                // Calculamos la distancia desde la puerta hasta el enemigo
                float distancia = Vector3.Distance(transform.position, enemigo.transform.position);

                // Si el enemigo está lejos
                if (distancia > 10f)
                {
                    // Le cortamos los frenos
                    if(enemigo.GetComponent<NavMeshAgent>() != null)
                    {
                        enemigo.GetComponent<NavMeshAgent>().isStopped = true;
                        enemigo.GetComponent<NavMeshAgent>().ResetPath();
                    }
                    
                    enemigo.enabled = false;
                }
            }
        }
    }
}
