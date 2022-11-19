using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Floor;
    public List<GameObject> Fls;
    public List<GameObject> Ter;
    public GameManager Manager;

    Rigidbody _rb;
    public float ms = 10;
    public float jp = 10;
    bool OnFloor = true;

    
    Vector3 targetPos;
    Vector3 pos = new(0, 0, 0);
    Vector3 jump;
    
    
    int OnPos = 1; // 0 - Left; 1 - Center; 2 - Right;
    int z = 0;
    int tern = 0;
    int terz = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.position += new Vector3(0, 0, ms * Time.deltaTime);
        targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (Input.GetKeyDown(KeyCode.Space) && OnFloor == true)
        {
            jump = new Vector3(0, jp, 0);
            _rb.AddForce(jump);
            OnFloor = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && OnPos < 2) OnPos += 1;
        if (Input.GetKeyDown(KeyCode.A) && OnPos > 0) OnPos -= 1;
        if (OnPos == 2) targetPos += new Vector3(2, 0, 0);
        else if (OnPos == 0) targetPos += new Vector3(-2, 0, 0);
        transform.position = Vector3.Lerp(transform.position, targetPos, 10 * Time.deltaTime);

        if (transform.position.z > -5 + z + 20)
        {
            pos = new Vector3(0, -3, z + 60);
            GameObject a = Instantiate(Floor, pos, Quaternion.identity);
            Fls.Add(a);
            Destroy(Fls[0]);
            Fls.Remove(Fls[0]);
            z += 20;
        }
        if (transform.position.z > 991 + terz)
        {
            Ter[tern].transform.position += new Vector3(0, 0, 2000);
            if (tern == 0) tern = 1;
            else tern = 0;
            terz += 1000;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Floor") OnFloor = true;
        if (other.gameObject.tag == "Finish") Manager.GameOver();
    }
}
