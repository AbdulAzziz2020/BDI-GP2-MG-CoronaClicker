using System;
using Doozy.Runtime.Reactor;
using Doozy.Runtime.Reactor.Animators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;

public class GameView : MonoBehaviour
{
    [Header("GameView")] 
    public UIButton nextButton;
    public UIButton prevButton;
    public UIButton homeButton;

    [Header("Show And Hide!")]
    public UIButton showHideButton;
    public Image showHideImage;
    public Sprite showSprite;
    public Sprite hideSprite;
    private bool isHide = false;

    [Header("Show And Hide Animation")] 
    public UIAnimator nextAnim;
    public UIAnimator prevAnim;
    public UIAnimator pauseAnim;
    public UIAnimator homeAnim;
    public UIContainer shopAnim;
    public UIContainer healthBarAnim;

    [Header("OnPaused!")]
    public UIButton pauseButton;
    public GameObject pausePanel;
    public void ShowAndHide()
    {
        isHide = !isHide;
        showHideImage.sprite = !isHide ? showSprite : hideSprite;

        if (!isHide)
        {
            nextAnim.Play(PlayDirection.Forward);
            prevAnim.Play(PlayDirection.Forward);
            pauseAnim.Play(PlayDirection.Forward);
            homeAnim.Play(PlayDirection.Forward);
            healthBarAnim.Show();
            shopAnim.Show();
        }
        else
        {
            nextAnim.Play(PlayDirection.Reverse);
            prevAnim.Play(PlayDirection.Reverse);
            pauseAnim.Play(PlayDirection.Reverse);
            homeAnim.Play(PlayDirection.Reverse);
            healthBarAnim.Hide();
            shopAnim.Hide();
        }
    }

    public void OnPaused()
    {
        GameManager.Instance.isPause = !GameManager.Instance.isPause;
        pausePanel.SetActive(GameManager.Instance.isPause);
    }
}
