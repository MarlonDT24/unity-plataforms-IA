using UnityEngine;

public class InventarioJugador : MonoBehaviour
{
    public int monedas = 0; // Cuenta actual
    public int monedasParaGanar = 5; // Objetivo
    public Transform puntoVictoria; // Dónde iremos al ganar

    // Esta función llamará la moneda al ser recogida
    public void SumarMoneda()
    {
        monedas = monedas + 1;

        if (monedas >= monedasParaGanar)
        {
            GanarJuego();
        }
    }

    void GanarJuego()
    {   
        CharacterController control = GetComponent<CharacterController>();
        
        if (control != null) control.enabled = false;
        
        transform.position = puntoVictoria.position;
        
        if (control != null) control.enabled = true;
    }
}
