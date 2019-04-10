using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustoMappingTrackableEventHandler : DefaultTrackableEventHandler
{
    public Animator mappingAnimator;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        mappingAnimator.SetTrigger("Start");
        
    }
}
