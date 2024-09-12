using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeeGameManager : MonoBehaviour
{
    public GameObject backgroundObject;
    public GameObject beeObject;
    public GameObject flowerObject;
    public Button buttonHarvestFlower;

    private bool moveToFlower = false;

    // Bo sung co che tinh diem - PhuongBang
    public Text textPoint;
    private int point = 0;
    public SoundManager soundManager;
    public Button buttonNopMat;

    void Start()
    {
        buttonHarvestFlower.onClick.AddListener(Move2Flower);
        buttonNopMat.onClick.AddListener(ResetSize);
    }

    void Update()
    {
        if (moveToFlower)
        {
            beeObject.transform.localPosition = Vector3.MoveTowards(
                beeObject.transform.localPosition,
                new Vector3(flowerObject.transform.localPosition.x, beeObject.transform.localPosition.y, flowerObject.transform.localPosition.z),
                2 * Time.deltaTime);

            if (Vector3.Distance(beeObject.transform.localPosition, new Vector3(flowerObject.transform.localPosition.x, beeObject.transform.localPosition.y, flowerObject.transform.localPosition.z)) < 0.1f)
            {
                moveToFlower = false;
                RandomPosForFlower();
            }
        }
    }

    public void Move2Flower()
    {
        moveToFlower = true;
    }

    public void RandomPosForFlower()
    {
        float randomX = Random.Range(-4f, 4f);
        float randomZ = Random.Range(-2f, 2f);

        flowerObject.transform.localPosition = new Vector3(
            randomX,
            flowerObject.transform.localPosition.y,
            randomZ);

        // Bo sung co che tinh diem - PhuongBang
        point++;
        textPoint.text = "Point: " + point.ToString();

        // Bo sung tinh nang giup bee phat trien lon hon khi thu thap phan hoa - PhuongBang
        beeObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        soundManager.PlayVFX();
    }

    public void ResetSize()
    {
        beeObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
}
