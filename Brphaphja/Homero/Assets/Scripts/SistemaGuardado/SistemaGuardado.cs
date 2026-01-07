using UnityEngine;
using System.IO;

public class SistemaGuardado : MonoBehaviour
{
    private string saveFilePath;
    public int nivel = 1;

    private const int NIVEL_MAXIMO = 5;

    private void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/Guardado.txt";

        if (!File.Exists(saveFilePath))
        {
            File.WriteAllText(saveFilePath, "1");
        }
    }

    public void GuardarNivel(int nivel)
    {
        if (nivel > NIVEL_MAXIMO)
            nivel = NIVEL_MAXIMO;

        File.WriteAllText(saveFilePath, nivel.ToString());
        Debug.Log("Progreso guardado: Nivel " + nivel);
    }

    public int CargarNivel()
    {
        string contenido = File.ReadAllText(saveFilePath);
        int nivel = int.Parse(contenido);

        if (nivel > NIVEL_MAXIMO)
            nivel = NIVEL_MAXIMO;

        Debug.Log("Progreso cargado: Nivel " + nivel);
        return nivel;
    }

    public void BotonCargarNivel()
    {
        int nivel = CargarNivel();

        if (nivel > NIVEL_MAXIMO)
            nivel = NIVEL_MAXIMO;

        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel" + nivel);
    }
}

