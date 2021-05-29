using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public GameObject optionMenu;
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionButton()
    {
        StartCoroutine(SetActiveMenu(3f));
    }

    IEnumerator SetActiveMenu(float duration)
    {
        optionMenu.SetActive(true);
        yield return new WaitForSeconds(duration);
        optionMenu.SetActive(false);
    }
}
