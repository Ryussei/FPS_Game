using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivos : MonoBehaviour
{
    public int puntuacionObjeto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fuego")
        {
            GameManager.Instancia.PlayExplosion(1);
            GameManager.Instancia.puntaje += puntuacionObjeto;
            Destroy(this.gameObject);
        }
    }
}
