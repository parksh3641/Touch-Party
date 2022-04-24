using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NormalContent : MonoBehaviour, IContentEvent
{
    public GamePlayType gamePlayType = GamePlayType.GameChoice1;

    [SerializeField]
    private bool isActive = false;
    public int index = 0;
    public Text numberText;

    [Space]
    public UnityEvent clickEvent;
    public UnityEvent clickSoundEvent;
    public UnityEvent failSoundEvent;

    [Space]
    public Image backgroundImg;
    public Sprite[] backgroundImgList;

    [Space]
    [Title("FilpCard")]
    public Image filpCardImg;
    public Sprite[] filpCardImgList;

    [Space]
    [Title("ButtonAction")]
    public string[] buttonActionStrArray;

    void Awake()
    {
        clickSoundEvent.AddListener(() => { GameObject.FindWithTag("ClickSound").GetComponent<AudioSource>().Play(); });
        failSoundEvent.AddListener(() => { GameObject.FindWithTag("FailSound").GetComponent<AudioSource>().Play(); });

        numberText.text = "";

        filpCardImg.enabled = false;
    }

    public void Initialize(GamePlayType type)
    {
        gamePlayType = type;

        clickEvent.RemoveAllListeners();

        switch (type)
        {
            case GamePlayType.GameChoice1:
                clickEvent.AddListener(() => { GameObject.FindWithTag("GameManager").GetComponent<GameManager>().CheckNumber(index, ChoiceAction); });
                break;
            case GamePlayType.GameChoice2:
                clickEvent.AddListener(() => { GameObject.FindWithTag("GameManager").GetComponent<GameManager>().CheckMole(index, ChoiceMoleAction); });
                break;
            case GamePlayType.GameChoice3:
                clickEvent.AddListener(() => { GameObject.FindWithTag("GameManager").GetComponent<GameManager>().CheckFilpCard(index, isActive, ChoiceCardAction); });
                break;
            case GamePlayType.GameChoice4:
                clickEvent.AddListener(() => { GameObject.FindWithTag("GameManager").GetComponent<GameManager>().CheckButtonAction(index, ChoiceButtonAction); });
                break;
            case GamePlayType.GameChoice5:
                break;
            case GamePlayType.GameChoice6:
                break;
            case GamePlayType.GameChoice7:
                break;
            case GamePlayType.GameChoice8:
                break;
        }
    }

    public void OnReset()
    {
        backgroundImg.sprite = backgroundImgList[0];

        isActive = true;
    }

    public void NormalReset(int number)
    {
        index = number;
        numberText.text = index.ToString();

        backgroundImg.sprite = backgroundImgList[0];
        backgroundImg.enabled = true;

        isActive = true;
    }

    public void FilpCardReset(int number)
    {
        filpCardImg.sprite = filpCardImgList[number];
        filpCardImg.enabled = false;
        index = number;

        isActive = true;
    }

    public void ButtonActionReset(int number)
    {
        backgroundImg.sprite = backgroundImgList[0];
        numberText.text = buttonActionStrArray[number];
        index = number;

        isActive = true;
    }

    public void First()
    {
        backgroundImg.sprite = backgroundImgList[1];
    }


    public void Choice()
    {
        clickSoundEvent.Invoke();

        if(isActive)
        {
            clickEvent.Invoke();
        }
    }

    public void ChoiceAction(bool check)
    {
        if(check)
        {
            isActive = false;

            backgroundImg.enabled = false;
            numberText.text = "";
        }
        else
        {
            failSoundEvent.Invoke();
        }
    }

    public void ChoiceMoleAction(bool check)
    {
        if (check)
        {
            isActive = false;

            backgroundImg.sprite = backgroundImgList[0];
        }
        else
        {
            failSoundEvent.Invoke();
        }
    }

    public void ChoiceCardAction(int check)
    {
        switch(check)
        {
            case 0:
                isActive = false;

                filpCardImg.enabled = true;
                break;
            case 1:
                isActive = false;

                filpCardImg.enabled = true;

                break;
            case 2:
                isActive = true;

                filpCardImg.enabled = false;

                failSoundEvent.Invoke();
                break;
        }
    }

    public void ChoiceButtonAction(bool check)
    {
        if(check)
        {

        }
        else
        {
            failSoundEvent.Invoke();
        }
    }

    public int GetIndex()
    {
        return index;
    }
}
