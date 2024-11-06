using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ResolutionButton : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    // Lista de resolu��es
    private Resolution[] _resolutions;

    void Start()
    {
        // Popula o array de resolu��es atrav�s do built-in Screen.resolutions
        _resolutions = Screen.resolutions;

        // Limpa as op��es padr�es do Dropdown
        resolutionDropdown.ClearOptions();

        // Criamos uma lista vazia para armazenar as resolu��es em um formato leg�vel
        List<string> options = new List<string>();
        int _curResolutionIndex = 0;

        // Popula a lista de op��es e setta o valor atual da resolu��o na vari�vel _curResolutionIndex
        for (int i = 0; i < _resolutions.Length; i++) 
        { 
            string option = _resolutions[i].ToString();
            options.Add(option);

            if (_resolutions[i].width == Screen.currentResolution.width &&
                _resolutions[i].height == Screen.currentResolution.height)
            {
                _curResolutionIndex = i;
            }
        }

        // Adiciona as novas op��es ao Dropdown
        resolutionDropdown.AddOptions(options);

        int savedResolutionIndex = PlayerPrefs.GetInt("resolutionIndex", _curResolutionIndex);
        // Defini a resolu��o atual
        resolutionDropdown.value = savedResolutionIndex;
        print(_curResolutionIndex);
        resolutionDropdown.RefreshShownValue();
        SetResolution(savedResolutionIndex);

        // Adiciona um Listener para chamar a fun��o SetResolution toda vez que uma op��o � selecionada
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    /// <summary>
    /// Define a resolu��o da tela baseado no �ndice do Dropdown
    /// </summary>
    /// <param name="resolutionIndex"></param>
    private void SetResolution(int resolutionIndex)
    {
        Resolution selectedRes = _resolutions[resolutionIndex];
        Screen.SetResolution(selectedRes.width, selectedRes.height, Screen.fullScreen);

        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
    }
}
