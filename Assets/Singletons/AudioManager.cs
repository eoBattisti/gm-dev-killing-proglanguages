using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Valida caso não esteja salvo a configuração de aúdio,
        // automaticamente é salvo e posteriormente é settado o volumeSlider.value
        // na função Load
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        Load();
    }

    /// <summary>
    /// Alterar o volume do AudioListener da cena baseado no valor do volumeSlider.
    /// </summary>
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }


    /// <summary>
    /// Carrega o valor salvo do volume do jogador através das PlayerPrefs para
    /// a propriedade value do volumeSlider
    /// </summary>
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");

    }


    /// <summary>
    /// Salva automaticamente o valor do volumeSlider.value nas PlayerPrefs
    /// </summary>
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
