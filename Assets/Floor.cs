using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public bool Spawned = true;
    public bool SpawnObj = true;
    private Vector3 TargetPos;

    public List<GameObject> Spawn;
    public List<GameObject> Obj;
    public GameObject Money;

    private int[] Line = { -1, -1, -1 };
    private int Pr = 0;

    private void Start()
    {
        int mn = 0;
        TargetPos = transform.position;
        TargetPos += new Vector3(0, 3, 0);
        if (Spawned == true && SpawnObj == true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Pr < 2)
                {
                    Line[i] = Random.Range(-1, 2);
                    if (Line[i] == 1) Pr++;
                }
                else Line[i] = Random.Range(-1, 1);
                mn = Random.Range(0,5);
                if (mn == 0)
                {
                    Vector3 tg = Spawn[i].transform.position;
                    tg += new Vector3(0, 0, -8);
                    GameObject a = Instantiate(Money, tg, Quaternion.identity);
                    a.transform.SetParent(this.gameObject.transform);
                }
            }
            for (int i = 0; i < 3; i++)
                if (Line[i] != -1)
                {
                    GameObject a = Instantiate(Obj[Line[i]], Spawn[i].transform.position, Quaternion.identity);
                    a.transform.SetParent(this.gameObject.transform);
                }
        }
    }
    private void Update()
    {
        if (Spawned == true) transform.position = Vector3.Lerp(transform.position, TargetPos, 10 * Time.deltaTime);
    }
}
