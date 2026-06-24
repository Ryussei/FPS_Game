using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{

    public GameObject municionTexto;
    public GameObject puntajeActualTexto;
    public GameObject PantallaGameover;
    public int cantidadMunicion = 10;
    public int puntaje;
    public Text txtPuntaje;
    public AudioSource projectileCollisionSound;
    public AudioSource projectileWallSound;
    private bool isOver = false;

    private static GameManager instancia = null;
    public static GameManager Instancia
    {
        get
        {
            return instancia;
        }
    }

    private void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
        }

        instancia = this;
    }

    void Update()
    {
        municionTexto.GetComponent<Text>().text = "Municion: " + cantidadMunicion;
        puntajeActualTexto.GetComponent<Text>().text = "Puntaje: " + puntaje;
        if (cantidadMunicion <= 0 && !isOver) {
            isOver = true;
            StartCoroutine(ExecuteAfterTime(3));
         } 
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        GameOver();
    }

    private void GameOver()
    {
        txtPuntaje.text = "Puntuacion: " + puntaje;
        PantallaGameover.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
    }

    public void BtnReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        cantidadMunicion = 10;
        PantallaGameover.gameObject.SetActive(false);
    }

    public void PlayExplosion(int type)
    {
        if(type == 1) projectileCollisionSound.Play();
        if(type == 2) projectileWallSound.Play();
    }

}
