using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayQuit : MonoBehaviour
{
    public void PlayGame ()
        //usado para poder avançar para uma cena seguinte
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void BackGame ()
    {
    	if (SceneManager.GetActiveScene().buildIndex == 4)
    	{
    		SceneManager.LoadScene(2);
    	}
    	else if (SceneManager.GetActiveScene().buildIndex == 7)
    	{
    		SceneManager.LoadScene(4);
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
