using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VR_MY_GARB : XRDirectInteractor
{
    public VR_Rope rope;
    public Transform arm;
    public XRController conttroll;

    private void Start()
    {
        rope = GetComponent<VR_Rope>();
        conttroll = GetComponent<XRController>();
    }

    //protected override void OnSelectEntered(XRBaseInteractable interactable)
    //{
    //    if (interactable.gameObject.GetComponent<Rigidbody>().isKinematic == true)
    //    {
    //        interactable.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //    }
    //}

    public void Get()
    {
        rope.enabled = true;
        arm = GameObject.Find("RightHand Controller").transform;
    }

    void Out()
    {

    }

}
