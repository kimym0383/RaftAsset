using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Hook : MonoBehaviour
{
    [SerializeField] VR_Rope rope;
    [SerializeField] public Rigidbody rigi;
    [SerializeField] Transform hook;
    [SerializeField] Transform player;
    [SerializeField] public List<GameObject> colObj;
    [SerializeField] public bool isCoroutine = true;

    private void Awake()
    {
        rope = GetComponent<VR_Rope>();
    }

    private void Update()
    {

    }

    public void Get()
    {
        rope.enabled = true;
    }

    public void Out()
    {
        Invoke("DisableRope", 3f);
    }

    void DisableRope()
    {
        rope.enabled = false;
        rope.ClearLineRenderer();
    }

    private void OnTriggerEnter(Collider get)
    {
        if(get.gameObject.CompareTag("Object"))
        {
            rigi.isKinematic = true;
            get.gameObject.GetComponent<WaterObject>().enabled = false;
            GameObject obj = get.gameObject;

            if (!colObj.Contains(obj))
            {
                colObj.Add(obj);
            }

            StartCoroutine(GetObj(obj));
        }        
    }

    IEnumerator GetObj(GameObject obj)
    {
        while (isCoroutine)
        {
            obj.transform.position = Vector3.MoveTowards(hook.transform.position, player.transform.position, Time.deltaTime * 3f);
            hook.transform.position = Vector3.MoveTowards(hook.transform.position, player.transform.position, Time.deltaTime * 3f);
            yield return null;
        }
    }
}
