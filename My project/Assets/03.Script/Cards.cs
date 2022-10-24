using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public GameObject[] cards;
    public int[] nums;

    public List<int> numList;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        CreateCard();
    }

    public void CreateCard()
    {
        numList = new List<int>() { 0, 1, 2, 3 };

        numList.RemoveAt(Random.Range(0, numList.Count));

        for(int i = 0; i < numList.Count; i++)
        {
            cards[numList[i]].SetActive(true);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].SetActive(false);
        }
    }
}
