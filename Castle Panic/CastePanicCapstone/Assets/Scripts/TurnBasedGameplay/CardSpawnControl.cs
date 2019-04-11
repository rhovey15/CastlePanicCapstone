using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How do I check if an object contains a child?
//https://answers.unity.com/questions/341232/spawn-prefabs-as-children-of-another-game-object.html

//Spawn Prefabs as Children of Another Game Object
//https://answers.unity.com/questions/341232/spawn-prefabs-as-children-of-another-game-object.html

public class CardSpawnControl : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] cards;
    public System.Random rand = new System.Random();
    int randomCard;
    public int cardSpawnPointIterator;

    public void DealACard()
    {
        if(spawnPoints[cardSpawnPointIterator].childCount == 0)
        {
            randomCard = rand.Next(0, cards.Length);

            GameObject cardObject = UnityEngine.Object.Instantiate(cards[randomCard], spawnPoints[cardSpawnPointIterator].position,
                Quaternion.identity);

            DragGameObject cardDetails = cardObject.GetComponent<DragGameObject>();
            cardDetails.spawnPoint = spawnPoints[cardSpawnPointIterator];

            cardObject.transform.parent = spawnPoints[cardSpawnPointIterator];
        }
           
    }
}
