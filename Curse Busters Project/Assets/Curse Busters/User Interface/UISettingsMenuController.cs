using UnityEngine;

[RequireComponent (typeof (CanvasRenderer))]
public class UISettingsMenuController : MonoBehaviour 
{
    /// <summary></summary>
    /// <param name="panel"></param>
    public void DisplayMenu (GameObject panel)
    {
        this.gameObject.SetActive (false);
        panel.gameObject.SetActive (true);
    }
}
