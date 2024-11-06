using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Vari�vel para ser acessada atrav�s de qualquer outro script do jogo
    // fazendo com que o objeto se torne um Singleton
    public static SceneController Instance { get; private set; }

    /// <summary>
    /// Validamos para que uma inst�ncia de um SceneController j� exista,
    /// caso qualquer objeto subsequente seja encontrado, ser� destru�do.
    /// 
    /// Essa fun��o tem o objetivo de colocar um comportamento de Singleton na classe/objeto.
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    /// <summary>
    /// Realiza a troca de cenas pelo nome da cena.
    /// </summary>
    /// <param name="name"></param>
    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// Sai do jogo
    /// </summary>
    public void QuitGame()
    {
        #if UNITY_EDITOR 
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
