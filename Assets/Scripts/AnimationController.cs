using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Sprite heartSprite;
    public GameObject packman;
    public GameObject points;
    public Image packmanImage;
    public Sprite closedMouth;
    public Sprite openedMouth;
    public GameObject[] frames;
    public List<GameObject> windows;

    public List<GameObject> windowsLogo;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void ChangeHeartSprite(Image image)
    {
        image.sprite = heartSprite;
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

            yield return new WaitForSeconds(0.1f);

            packmanImage.sprite = openedMouth;

            yield return new WaitForSeconds(0.1f);

        }
    }

    public void StartPackman()
    {
        packman.SetActive(true);

        points.SetActive(true);

        StartCoroutine(ChangePositionGO(packman, new Vector2(-250f, 135f), new Vector2(2800f, 135f), 3.5f));

        StartCoroutine(PackmanEat());
    }

    public void StopPackman()
    {
        packman.SetActive(false);
    }

    public void Show25Frame()
    {
        StartCoroutine(ActivateFrame());
    }

    IEnumerator ActivateFrame()
    {
        foreach (var go in frames)
        {
            go.SetActive(true);

            yield return new WaitForSeconds(0.2f);

            go.SetActive(false);

            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator WindowsShow()
    {
        foreach (GameObject window in windows)
        {
            window.SetActive(true);
            yield return ChangePositionGO(window, window.transform.position, new Vector2(1100f, 600f), 0.3f);
        }

    }

    public void ShowWindows()
    {  
        StartCoroutine(WindowsShow());
    }

    public void WindowsHide()
    {
        foreach (GameObject window in windows)
            window.SetActive(false);
    }
    
    IEnumerator ShowWindowsLogo()
    {
        foreach (GameObject logo in windowsLogo)
        {
            logo.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator WindowsLogos()
    {
        yield return StartCoroutine(ShowWindowsLogo());

        foreach (GameObject logo in windowsLogo)
        {
            StartCoroutine(ChangePositionGO(logo, logo.transform.position, new Vector2(1100f, 600f), 0.3f));
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






}
