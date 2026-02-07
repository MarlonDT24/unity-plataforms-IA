using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movimiento : MonoBehaviour
{
    public CharacterController cc_control;
    public float velocidadCaminar = 10f;
    public float velocidadVuelo = 15f;
    public float velocidadGiro = 2f;

    public float gravedad = -9.81f;
    public float fuerzaSalto = 3f;

    public Transform groundCheck;
    public float radioSuelo = 0.4f;
    public LayerMask maskSuelo;

    Vector3 velocidadCaida;
    bool tocaSuelo;
    bool modoVuelo = false;

    void Update()
    {
        // 1. Alternamos el modo vuelo con la tecla "F"
        if (Input.GetKeyDown(KeyCode.F))
        {
            modoVuelo = !modoVuelo;
            velocidadCaida = Vector3.zero;
        }

        // Rotación con el ratón
        float ratonX = Input.GetAxis("Mouse X") * velocidadGiro;
        transform.Rotate(Vector3.up * ratonX);

        // Inputs de movimiento (WASD)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 mover = transform.right * x + transform.forward * z;

        if (modoVuelo)
        {
            // COMPORTAMIENTO VOLANDO ---
            cc_control.Move(mover * velocidadVuelo * Time.deltaTime);

            // Subir con Espacio, Bajar con Shift Izquierdo
            if (Input.GetKey(KeyCode.Space))
            {
                cc_control.Move(Vector3.up * velocidadVuelo * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                cc_control.Move(Vector3.down * velocidadVuelo * Time.deltaTime);
            }
        }
        else
        {
            // COMPORTAMIENTO CAMINANDO
            tocaSuelo = Physics.CheckSphere(groundCheck.position, radioSuelo, maskSuelo);

            if (tocaSuelo && velocidadCaida.y < 0)
            {
                velocidadCaida.y = -2f; 
            }

            cc_control.Move(mover * velocidadCaminar * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && tocaSuelo)
            {
                velocidadCaida.y = Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
            }

            // Aplica gravedad
            velocidadCaida.y += gravedad * Time.deltaTime;
            cc_control.Move(velocidadCaida * Time.deltaTime);
        }
    }
}
