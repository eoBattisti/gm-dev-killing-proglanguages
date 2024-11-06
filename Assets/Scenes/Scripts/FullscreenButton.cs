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
    /// Método para ser utilizado através do Botão OnClick event
    /// Através do built-in Screen.fullScreen utilizando o operador de desigualdade
    /// o próprio valor é alterado para True ou False
    /// </summary>
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        UpdateButtonText();
    }


    /// <summary>
    /// Altera o texto do botão através do valor de Screen.fullScreen ser True/False
    /// </summary>
    private void UpdateButtonText()
    {
        if (buttonText != null)
        {
            buttonText.text = Screen.fullScreen ? "Windowed" : "Fullscreen";
        }

    }

}
