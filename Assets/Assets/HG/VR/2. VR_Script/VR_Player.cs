using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Player : MonoBehaviour
{
    [SerializeField] VR_Hook hook;
    [SerializeField] VR_Rope rope;
    [SerializeField] Transform tr;

    [SerializeField] bool isSea = false;

    private void Awake()
    {
        hook.colObj = FindObjectOfType<VR_Hook>().colObj;
        rope = FindObjectOfType<VR_Rope>();
    }

    private void Update()
    {
        if (isSea)
        {
            Sea();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            collision.gameObject.SetActive(false);
            Invoke("Return", 2f);
            Destroy(collision.gameObject);
            Return();
        }
        else if(isSea && collision.gameObject.CompareTag("Ground"))
        {
            isSea = false;
            Vector3 forceDirection = new Vector3(0f, 1f, 0f);
            float forceMagnitude = 10f;
            GetComponent<Rigidbody>().AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sea"))
        {
            isSea = true;
        }
    }

    void Return()
    {
        hook.isCoroutine = false;
        hook.rigi.isKinematic = false;
        rope.ClearLineRenderer();
    }

    void Sea()
    {
        Vector3 newPosition = new Vector3(tr.position.x, 10f, tr.position.z);
        tr.position = newPosition;
    }
}
