using UnityEngine;

public class Moneda : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();

            if (inventario != null)
            {
                inventario.SumarMoneda();
                Destroy(gameObject);
            }
        }
    }
}