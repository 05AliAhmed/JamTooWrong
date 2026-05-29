using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
