using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text FPS;
    List<Box> boxes = new List<Box>();
    [SerializeField] GameObject cube;
    [SerializeField] Transform container;
    int dem = 0;
    private void Start()
    {
        for (int i = -50; i < 50; i+=1)
        {
            for (int j = -50; j < 50; j+=1)
            {
                var t = Instantiate(cube, new Vector3((float)i/10, 0, (float)j / 10), Quaternion.identity, container);
                Box b= new Box();
                b.GetI();
                b.transform1 = t.transform;
                boxes.Add(b);
                dem++;
            }
        }
        Debug.Log(dem);
    }

    void CalculateFPS()
    {
        FPS.text = "FPS: " + (1 / Time.deltaTime).ToString();
    }
    private void Update()
    {
        CalculateFPS();
    }
    private void FixedUpdate()
    {
        foreach (var box in boxes)
        {
            box.Moving();
        }
    }

}
[System.Serializable]
public class Box
{
    [SerializeField] float speed = 0.05f;
    public Transform transform1;
    int i = 0;
    public void GetI()
    {
        i = Random.Range(0, 2);
    }

    public void Moving()
    {
        if (i == 0)
        {
            transform1.position += new Vector3(0, speed * Time.deltaTime, 0);
            if (Mathf.Abs(transform1.position.y) > 0.075f * 2)
            {
                speed = -speed;
            }
        }
        else
        {
            transform1.position -= new Vector3(0, speed * Time.deltaTime, 0);
            if (Mathf.Abs(transform1.position.y) > 0.075f * 2)
            {
                speed = -speed;
            }
        }
    }
}