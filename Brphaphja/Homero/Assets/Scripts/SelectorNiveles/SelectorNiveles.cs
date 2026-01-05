using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectorNiveles : MonoBehaviour
{
    public GameObject nivelButtonPrefab;
    public Transform buttonContainer;
    public int totalLevels = 5;

    void Start()
    {
      GenerateLevelButtons();
    }

    void GenerateLevelButtons()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
            GameObject buttonObj = Instantiate(nivelButtonPrefab, buttonContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Nivel" + i;

            int levelIndex = i;
            buttonObj.GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Nivel" + levelIndex);
            });
        }
        
        
    }
}