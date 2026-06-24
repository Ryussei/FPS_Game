using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour
{
    public GameObject prefabProyectil;
    private GameObject proyectilActual;

    private void DispararFuego()
    {
        float yRot = transform.rotation.eulerAngles.y;
        Vector3 forwardY = Quaternion.Euler(0.0f, yRot, 0.0f) * Vector3.forward;
        proyectilActual = GameObject.Instantiate(prefabProyectil);

        //Posicion inicial del proyectil
        proyectilActual.transform.position = transform.position + forwardY;
        proyectilActual.transform.rotation = transform.rotation;
        GameManager.Instancia.cantidadMunicion -= 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instancia.cantidadMunicion > 0)
        {
            DispararFuego();
        }
    }
}