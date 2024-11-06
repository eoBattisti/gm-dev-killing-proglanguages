using TMPro;
using UnityEngine;

public class FullscreenButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;

    void Start()
    {
        UpdateButtonText();
    }

    /// <summary>
    /// M�todo para ser utilizado atrav�s do Bot�o OnClick event
    /// Atrav�s do built-in Screen.fullScreen utilizando o operador de desigualdade
    /// o pr�prio valor � alterado para True ou False
    /// </summary>
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        UpdateButtonText();
    }


    /// <summary>
    /// Altera o texto do bot�o atrav�s do valor de Screen.fullScreen ser True/False
    /// </summary>
    private void UpdateButtonText()
    {
        if (buttonText != null)
        {
            buttonText.text = Screen.fullScreen ? "Windowed" : "Fullscreen";
        }

    }

}
