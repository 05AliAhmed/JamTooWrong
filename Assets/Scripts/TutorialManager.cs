using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject phase5;
    public GameObject phase6;
    public GameObject button;

    int currentPhase = 1;

    void Start()
    {
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase3.SetActive(false);
        phase4.SetActive(false);
        phase5.SetActive(false); 
        phase6.SetActive(false);
        button.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextPhase();
        }
    }

    void NextPhase()
    {
        if (currentPhase == 1)
        {
            phase1.SetActive(false);
            phase2.SetActive(true);
        }
        else if (currentPhase == 2)
        {
            phase2.SetActive(false);
            phase3.SetActive(true);
        }
        else if (currentPhase == 3)
        {
            phase3.SetActive(false);
            phase4.SetActive(true);
        }
        if (currentPhase == 4)
        {
            phase4.SetActive(false);
            phase5.SetActive(true);
        }
        else if (currentPhase == 5)
        {
            phase5.SetActive(false);
            phase6.SetActive(true);
            button.SetActive(true);
        }
        

        currentPhase++;
    }
}


