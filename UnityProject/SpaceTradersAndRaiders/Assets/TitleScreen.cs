using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsButton()
    {

    }

    public void CreditsButton()
    {

    }

    public void BugReportButton()
    {
        Application.OpenURL("https://docs.google.com/forms/d/1-3Q5EJZIslwdZO9bhTgAmUpyy94d0bxHcpxhno4gGV8/edit");
    }
}
