using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (CanvasRenderer))]
public class UIMenuController : MonoBehaviour 
{
    /// <summary></summary>
    /// <param name="index"></param>
    public void LoadScene (int index)
    {
        SceneManager.LoadScene (index);
    }

    /// <summary></summary>
    /// <param name="name"></param>
    public void LoadScene (string name)
    {
        SceneManager.LoadScene (name);
    }

    /// <summary></summary>
    /// <param name="panel"></param>
    public void DisplayMenu (GameObject panel)
    {
        this.gameObject.SetActive (false);
        panel.gameObject.SetActive (true);
    }
}
