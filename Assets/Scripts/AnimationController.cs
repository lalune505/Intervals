using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Sprite heartSprite;
    public GameObject hearts;
    public Image[] imHearts;
    public GameObject packman;
    public GameObject points;
    public Image packmanImage;
    public Sprite closedMouth;
    public Sprite openedMouth;
    public GameObject[] frames;
    public List<GameObject> windows;
    public List<GameObject> windowsLogo;
    public List<GameObject> notificationImages;
    public GameObject incCallPanel;
    public GameObject smileImage;
    public GameObject textField;
    public GameObject brainPanel;
    private Text txt;
    private string story;
    private float a;

    private float _currentScale = InitScale;
    private const float TargetScale = 3f;
    private const float InitScale = 1f;
    private const int FramesCount = 100;
    private const float AnimationTimeSeconds = 2;
    private float _deltaTime = AnimationTimeSeconds / FramesCount;
    private float _dx = (TargetScale - InitScale) / FramesCount;
    private bool _upScale = true;


    // Start is called before the first frame update
    void Start()
    {
        txt = textField.GetComponent<Text>();
        story = txt.text;
        a = 0.13f;
        txt.text = "";

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void ChangeHeartSprite()
    {
        StartCoroutine(HeartSprite());

    }
    IEnumerator HeartSprite()
    {
        imHearts[0].sprite = heartSprite;
        yield return new WaitForSeconds(25f);

        imHearts[1].sprite = heartSprite;
        yield return new WaitForSeconds(40f);

        imHearts[2].sprite = heartSprite;
        yield return new WaitForSeconds(30f);

        imHearts[3].sprite = heartSprite;
        yield return new WaitForSeconds(20f);

        imHearts[4].sprite = heartSprite;
        yield return new WaitForSeconds(30f);

        imHearts[5].sprite = heartSprite;
        yield return new WaitForSeconds(40f);

        imHearts[6].sprite = heartSprite;
        yield return null;

    }
    public void ShowHearts()
    {
        hearts.SetActive(true);
    }
    IEnumerator ChangePositionGO(GameObject go, Vector2 origin, Vector2 target,float duration)
    {
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;

            float percent = Mathf.Clamp01(timePassed / duration);

            go.transform.position = Vector2.Lerp(origin, target, percent);

            yield return null;

        }

    }

    IEnumerator PackmanEat()
    {
        while (packman.activeSelf)
        {
            packmanImage.sprite = closedMouth;

            yield return new WaitForSeconds(0.2f);

            packmanImage.sprite = openedMouth;

            yield return new WaitForSeconds(0.2f);

        }
    }

    public void StartPackman()
    {
        packman.SetActive(true);

        points.SetActive(true);

        StartCoroutine(ChangePositionGO(packman, new Vector2(-250f, 135f), new Vector2(2800f, 135f), 6f));

        StartCoroutine(PackmanEat());
    }

    public void StopPackman()
    {
        packman.SetActive(false);
    }

    public void Show25Frame()
    {
        StartCoroutine(ActivateFrame(30f));
    }

    IEnumerator ActivateFrame(float interval)
    {
        foreach (var go in frames)
        {
            go.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            go.SetActive(false);

            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator WindowsShow()
    {
      
        foreach (GameObject window in windows)
        {
            window.SetActive(true);
            yield return ChangePositionGO(window, window.transform.position, window.transform.parent.position, 0.4f);
        }

    }

    public void ShowWindows()
    {  
        StartCoroutine(WindowsShow());
    }

    public void HideWindows()
    {
        foreach (GameObject window in windows)
            window.SetActive(false);
    }
    
    IEnumerator ShowWindowsLogo()
    {
        foreach (GameObject logo in windowsLogo)
        {
            logo.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator WindowsLogos()
    {
        yield return StartCoroutine(ShowWindowsLogo());

        foreach (GameObject logo in windowsLogo)
        {
            StartCoroutine(ChangePositionGO(logo, logo.transform.position, logo.transform.parent.position, 0.3f));
        }

        yield return new WaitForSeconds(1f);

        foreach (GameObject logo in windowsLogo)
        {
            logo.SetActive(false);
        }
    }

    public void ShowLogos()
    {
        StartCoroutine(WindowsLogos());
    }

    IEnumerator Notification1()
    {
        foreach (GameObject notificationImage in notificationImages)
        {
            notificationImage.SetActive(true);
            Vector3 prevPosition = notificationImage.transform.position;
            yield return StartCoroutine(ChangePositionGO(notificationImage, notificationImage.transform.position, notificationImage.transform.parent.position, 0.2f));
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(ChangePositionGO(notificationImage, notificationImage.transform.position, prevPosition, 0.2f));
            notificationImage.SetActive(false);
        }
    
    }

    public void ShowNotifications()
    {
        StartCoroutine(Notification1());
    }


    IEnumerator PanelActivation(GameObject panel, float duration)
    {
        panel.SetActive(true);

        yield return new WaitForSeconds(duration);

        panel.SetActive(false);
    }

    public void ShowHideIncCall()
    {
        StartCoroutine(PanelActivation(incCallPanel, 5f));
    }

    public void ShowHideSmile()
    {
        StartCoroutine(PanelActivation(smileImage, 1f));
    }

    public void ShowTWText()
    {
        textField.SetActive(true);

        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            a -= 0.001f;
            txt.text += c;
            yield return new WaitForSeconds(a);
        }
        yield return StartCoroutine(UpScale());
        textField.SetActive(false);
    }

    IEnumerator UpScale()
    {
        while (_upScale)
        {
            _currentScale += _dx;
            if (_currentScale > TargetScale)
            {
                _upScale = false;
                _currentScale = TargetScale;
            }
            textField.transform.localScale= Vector3.one * _currentScale;
            yield return new WaitForSeconds(_deltaTime);
        }
    }

    public void ShowHideBrainPanel()
    {
        StartCoroutine(PanelActivation(brainPanel, 5f));
    }

    public void MappingEnd()
    {
        CanvasController.LoadScene(CanvasController.MenuScenePath);
    }
}
