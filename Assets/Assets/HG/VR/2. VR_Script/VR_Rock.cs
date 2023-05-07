using TMPro;
using UnityEngine;

public class VR_Rock : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TextMeshPro text;
    [SerializeField] GameObject prefab;
    [SerializeField] int hp = 0;

    private bool isPrefabCreated = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        text.text = "HP : " + hp.ToString();

        if (hp == 0 && !isPrefabCreated)
        {
            anim.SetTrigger("Die");
            prefab = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.identity);
            isPrefabCreated = true;
            Invoke("Destroy", 0.5f);
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            anim.SetTrigger("Hit");
            hp--;
        }
    }
}
