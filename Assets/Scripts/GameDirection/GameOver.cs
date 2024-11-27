using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

enum characters{
    einstein = 0,
    sabrina = 1,
}
public class GameOver : MonoBehaviour
{


    public TMP_Text gameOverText;
    public GameObject einsteinBazooka;
    public GameObject gameOverSequence;

    public ExplosionTriggerScript explosionTrigger;

    public Animator[] animationCharacters;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOverScreen(bool isWinner)
    {
        animationCharacters[(int)characters.sabrina].enabled = true;
        if (isWinner)
        {
            gameOverSequence.SetActive(true);
            einsteinBazooka.SetActive(true);
            explosionTrigger.enabled = true;
            animationCharacters[(int)characters.sabrina].Rebind();
            animationCharacters[(int)characters.sabrina].SetBool("isAlive", false);
            animationCharacters[(int)characters.sabrina].Play("DeadBody");
            gameOverText.text = "Your answer is correct! FATALITY!";
            AudioController.Instance.PlayEinsteinWinBGM();
        }
        else
        {
            gameOverSequence.SetActive(true);
            einsteinBazooka.SetActive(false);
            explosionTrigger.StopEinsteinExplosion();
            animationCharacters[(int)characters.sabrina].Rebind();
            animationCharacters[(int)characters.sabrina].SetBool("isAlive", true);
            animationCharacters[(int)characters.sabrina].Play("Alive");
            explosionTrigger.enabled = false;
            gameOverText.text = "Your answer is wrong! Idiocracy always wins!";
            AudioController.Instance.PlaySabrinaWinBGM();

        }
    }

    public void hideGameOverScreen()
    {
        gameOverSequence.SetActive(false);
    }


}
