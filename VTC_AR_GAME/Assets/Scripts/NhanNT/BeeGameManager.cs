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

    void Start()
    {
        buttonHarvestFlower.onClick.AddListener(Move2Flower);
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
    }
}
