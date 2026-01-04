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
    public float tiempoEspera = 3f;

    // Start is called before the first frame update
    void Start()
    {
        miJugador = GameObject.FindWithTag("Jugador");
        miEnemigo = this.gameObject;
        asistenteEnemigo = miEnemigo.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
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
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject jugadorCapturado = collision.gameObject;

        if (jugadorCapturado.tag == "Jugador")
        {
            asistenteEnemigo.isStopped = true;
            GetComponent<Collider>().enabled = false;
            Destroy(jugadorCapturado);
            StartCoroutine(GameOver());
        }
    }
}
