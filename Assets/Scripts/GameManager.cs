using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource MainMenuaudio;
    public AudioSource GameplayAudio;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        MainMenuaudio.Play();
        GameplayAudio.Stop();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Gameplay Scene
        if (scene.buildIndex == 1)
        {
            MainMenuaudio.Stop();

            if (!GameplayAudio.isPlaying)
            {
                GameplayAudio.Play();
            }
        }
        else
        {
            GameplayAudio.Stop();

            if (!MainMenuaudio.isPlaying)
            {
                MainMenuaudio.Play();
            }
        }
    }

    public IEnumerator LoadScene(int _sceneindex)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(3);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(_sceneindex);
    }

    public void GMLoadScene(int _sceneindex)
    {
        StartCoroutine(LoadScene(_sceneindex));
    }
}