// Attach this script to an empty GameObject.
// Create three buttons (Create>UI>Button). Next, select your
// empty GameObject in the Hierarchy and click and drag each of your
// Buttons from the Hierarchy to the Your First Button, Your Second Button
// and Your Third Button fields in the Inspector.
// Click each Button in Play Mode to output their message to the console.
// Note that click means press down and then release.

using UnityEngine;
using UnityEngine.UI;

public class SaveBTNValues : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_FirstButton, m_SecondButton, m_ThirdButton;

    public double value;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_FirstButton.onClick.AddListener(SaveValue1);
        m_SecondButton.onClick.AddListener(SaveValue2);
        m_ThirdButton.onClick.AddListener(SaveValue3);
    }

    void SaveValue1()
    {
        //Output this to console when Button1 clicked
        value = 0.10;
        Debug.Log(value);
    }

    void SaveValue2()
    {
        //Output this to console when the Button2 is clicked
        value = 0.50;
        Debug.Log(value);
    }

    void SaveValue3()
    {
        //Output this to console when the Button3 is clicked
        value = 0.95;
        Debug.Log(value);
    }
}
