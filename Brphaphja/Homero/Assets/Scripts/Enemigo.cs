using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemigo : MonoBehaviour
{
    private GameObject miEnemigo, miJugador;
    private NavMeshAgent asistenteEnemigo;
    public TextMeshProUGUI gameOver;
    public GameObject panel;
    private AudioSource cutted;
    public float tiempoEspera = 3f;
    private int nivel;

   
    void Start()
    {
        miJugador = GameObject.FindWithTag("Jugador");
        miEnemigo = this.gameObject;
        asistenteEnemigo = miEnemigo.GetComponent<NavMeshAgent>();
        nivel = SceneManager.GetActiveScene().buildIndex;
        cutted = miEnemigo.GetComponent<AudioSource>();
    }

  
    void Update()
    {
        if (miJugador != null)
        {
            asistenteEnemigo.destination = miJugador.transform.position;
        }
    }

    private IEnumerator GameOver()
    {
        gameOver.gameObject.SetActive(true);
        panel.SetActive(true);
        yield return new WaitForSeconds(tiempoEspera);
        if (nivel <= 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject jugadorCapturado = collision.gameObject;

        if (jugadorCapturado.tag == "Jugador")
        {
            cutted.Play();
            AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

            for (int i = 0; i < sonidos.Length; i++)
            {
                if (sonidos[i].CompareTag("Pausable"))
                    sonidos[i].Pause();
            }
            asistenteEnemigo.isStopped = true;
            GetComponent<Collider>().enabled = false;
            Destroy(jugadorCapturado);
            StartCoroutine(GameOver());
        }
    }
}
