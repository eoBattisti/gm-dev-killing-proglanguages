using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ResolutionButton : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    // Lista de resoluções
    private Resolution[] _resolutions;

    void Start()
    {
        // Popula o array de resoluções através do built-in Screen.resolutions
        _resolutions = Screen.resolutions;

        // Limpa as opções padrões do Dropdown
        resolutionDropdown.ClearOptions();

        // Criamos uma lista vazia para armazenar as resoluções em um formato legível
        List<string> options = new List<string>();
        int _curResolutionIndex = 0;

        // Popula a lista de opções e setta o valor atual da resolução na variável _curResolutionIndex
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

        // Adiciona as novas opções ao Dropdown
        resolutionDropdown.AddOptions(options);

        int savedResolutionIndex = PlayerPrefs.GetInt("resolutionIndex", _curResolutionIndex);
        // Defini a resolução atual
        resolutionDropdown.value = savedResolutionIndex;
        print(_curResolutionIndex);
        resolutionDropdown.RefreshShownValue();
        SetResolution(savedResolutionIndex);

        // Adiciona um Listener para chamar a função SetResolution toda vez que uma opção é selecionada
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    /// <summary>
    /// Define a resolução da tela baseado no índice do Dropdown
    /// </summary>
    /// <param name="resolutionIndex"></param>
    private void SetResolution(int resolutionIndex)
    {
        Resolution selectedRes = _resolutions[resolutionIndex];
        Screen.SetResolution(selectedRes.width, selectedRes.height, Screen.fullScreen);

        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
    }
}
