using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayQuit : MonoBehaviour
{

    public void ImmQuestion ()
    {
        SceneManager.LoadScene(4);
    }

    public void UnderConstruction ()
    {
        SceneManager.LoadScene(7);
    }

    public void PlayGame ()
        //usado para poder avançar para uma cena seguinte
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void BackGame ()
    {
    	if (SceneManager.GetActiveScene().buildIndex == 6)
    	{
    		SceneManager.LoadScene(4);
    	}
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
    		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    	}
    }

    public void QuitGame ()
    {
    	Debug.Log("Quit");
    	Application.Quit();
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }


}
