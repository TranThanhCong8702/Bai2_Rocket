using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] Transform container;
    int dem = 0;
    private void Start()
    {
        for (int i = -50; i < 50; i+=1)
        {
            for (int j = -50; j < 50; j+=1)
            {
                Instantiate(cube, new Vector3((float)i/10, 2f, (float)j / 10), Quaternion.identity, container);
                dem++;
            }
        }
        Debug.Log(dem);
    }
}
