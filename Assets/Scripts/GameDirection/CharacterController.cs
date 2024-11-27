using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.Video;
using UnityEngine.XR;
enum animationType{
    eyes = 0,
    life = 1
}
public class CharacterController : MonoBehaviour
{
    [SerializeField] Animator[] characterAnimatorEinstein;
    [SerializeField] Animator[] characterAnimatorSabrina;

    public GameOver gameOver;

    bool isGameAnswerCorrect;

// shows the death sequences
    public void showGameOverScreen(bool isCorrect)
    {

        if (isCorrect)
        {
            gameOver.gameOverScreen(true);
            AudioController.Instance.PlayEinsteinWinBGM();
        }
        else
        {
            gameOver.gameOverScreen(false);
            AudioController.Instance.PlaySabrinaWinBGM();

        }

        isGameAnswerCorrect = isCorrect;
        StartCoroutine(hideGameOverScreen());

    }

    IEnumerator hideGameOverScreen()
    {
        yield return new WaitForSeconds(6f);
        AudioController.Instance.StopMusic();
        gameOver.hideGameOverScreen();
        reloadIdleAnimations();

    }
// restarts the idle animations depending if the answer is correct or wrong.
    public void reloadIdleAnimations()
    {

        if (isGameAnswerCorrect)
        {
            characterAnimatorSabrina[(int)animationType.eyes].speed = 0;
            characterAnimatorSabrina[(int)animationType.eyes].enabled = false;
            characterAnimatorSabrina[(int)animationType.life].Rebind();
            characterAnimatorSabrina[(int)animationType.life].Play("IdleDeath");
            characterAnimatorEinstein[(int)animationType.life].Rebind();
            characterAnimatorEinstein[(int)animationType.life].Play("IdleAlive");
            characterAnimatorEinstein[(int)animationType.eyes].Rebind();
            characterAnimatorEinstein[(int)animationType.eyes].enabled = true;
            characterAnimatorEinstein[(int)animationType.eyes].speed = 1;
        }
        else
        {
            characterAnimatorEinstein[(int)animationType.eyes].speed = 0;
            characterAnimatorEinstein[(int)animationType.eyes].enabled = false;
            characterAnimatorEinstein[(int)animationType.life].Rebind();
            characterAnimatorEinstein[(int)animationType.life].Play("IdleDeath");
            characterAnimatorSabrina[(int)animationType.life].Rebind();
            characterAnimatorSabrina[(int)animationType.life].Play("IdleAlive");
            characterAnimatorSabrina[(int)animationType.eyes].Rebind();
            characterAnimatorSabrina[(int)animationType.eyes].enabled = true;
            characterAnimatorSabrina[(int)animationType.eyes].speed = 1;
        }

        
    }
}
