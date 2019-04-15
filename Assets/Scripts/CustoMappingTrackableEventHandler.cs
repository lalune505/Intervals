using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustoMappingTrackableEventHandler : DefaultTrackableEventHandler
{
    public Animator mappingAnimator;
    public GameObject panel;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        panel.SetActive(false);
        mappingAnimator.SetTrigger("Start");
        
    }
}
