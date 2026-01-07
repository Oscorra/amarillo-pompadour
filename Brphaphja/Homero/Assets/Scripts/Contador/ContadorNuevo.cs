using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ContadorObjetos : MonoBehaviour
{
    public Transform gameManager;
    public TextMeshProUGUI textoContador;

    void Update()
    {
        int cantidad = 0;

        foreach (Transform hijo in gameManager)
        {
            if (hijo.CompareTag("Eatable"))   
                cantidad++;
        }

        textoContador.text = $"{cantidad}";
    }
}
