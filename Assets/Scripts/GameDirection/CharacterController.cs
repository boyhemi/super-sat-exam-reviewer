using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
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

    // Start is called before the first frame update

    public void showGameOverScreen(bool isCorrect)
    {
        characterAnimatorEinstein[(int)animationType.eyes].speed = 0;
        characterAnimatorSabrina[(int)animationType.eyes].speed = 0;

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

        StartCoroutine(hideGameOverScreen());

    }

    IEnumerator hideGameOverScreen()
    {
        yield return new WaitForSeconds(6f);
        AudioController.Instance.StopMusic();
        gameOver.hideGameOverScreen();
        reloadIdleAnimations();

    }

    public void reloadIdleAnimations()
    {
        characterAnimatorEinstein[(int)animationType.eyes].speed = 1;
        characterAnimatorSabrina[(int)animationType.eyes].speed = 1;
    }
}
