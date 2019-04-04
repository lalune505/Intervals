using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationHandler : MonoBehaviour
{
    public Animator canvasAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region PUBLIC_METHODS
    public void OnStartAR()
    {
        CanvasController.LoadScene(CanvasController.LoadingScenePath);
    }

    public void LoadMenuScene()
    {
        CanvasController.LoadScene(CanvasController.MenuScenePath);
    }

    public void SetStickerScene()
    {
        CanvasController.SetSceneToLoad(CanvasController.StickerScenePath);
    }

    public void SetMappingScene()
    {
        CanvasController.SetSceneToLoad(CanvasController.MappingScenePath);
    }

    public void AnimatorSetTrigger(string trigger)
    {
        if (canvasAnimator != null)
        {
            canvasAnimator.SetTrigger(trigger);
        }

    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    #endregion //PUBLIC_METHODS
}
