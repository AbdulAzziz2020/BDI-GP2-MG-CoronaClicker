using System;
using Doozy.Runtime.Reactor;
using Doozy.Runtime.Reactor.Animators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;

public class GameView : SingletonMonoBehavior<GameView>
{
    [Header("GameView")] 
    public UIButton nextButton;
    public UIButton prevButton;
    public UIButton homeButton;
    public UIContainer GameOverPanel;

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

    [Header("PowerUp")] 
    public Player player;
    public ManagerPowerUp powerUp;
    public TMP_Text textCoin;
    public TMP_Text textHealth;
    public TMP_Text textDmg;
    public TMP_Text textCritRate;
    public TMP_Text textCritDmg;


    private void OnEnable()
    {
        powerUp.OnUpdateStatus += UpdateStatUI;
        player.OnUpdateStatUI += UpdateStatUI;
        
    }

    private void OnDisable()
    {
        powerUp.OnUpdateStatus -= UpdateStatUI;
        player.OnUpdateStatUI -= UpdateStatUI;
    }

    private void Start()
    {
        UpdateStatUI();
    }

    public void ShowAndHide()
    {
        isHide = !isHide;
        showHideImage.sprite = !isHide ? showSprite : hideSprite;
        
        AudioManager.Instance.PlaySFX("OnClick");

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
        
        AudioManager.Instance.PlaySFX("OnClick");
    }

    public void UpdateStatUI()
    {
        textCoin.text = player.coin.ToString();
        textHealth.text = player.health.ToString();
        textDmg.text = player.damage.ToString();
        textCritRate.text = player.critRate.ToString() +"%";
        textCritDmg.text = player.critDamage.ToString();
    }
}
