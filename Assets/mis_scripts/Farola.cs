using UnityEngine;

public class Farola : MonoBehaviour
{
    // Variable pública para arrastrar nuestra luz desde el editor
    public Light bombilla; 

    // Cuando entramos en el sensor se enciende
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos que sea el Jugador y no un enemigo o una moneda
        if (other.CompareTag("Player")) 
        {
            bombilla.enabled = true; // ¡Luz encendida!
        }
    }

    // Cuando salimos del sensor se apaga
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bombilla.enabled = false;
        }
    }
}
