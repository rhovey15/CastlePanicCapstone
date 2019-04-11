using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGameObject : MonoBehaviour
{
    public string cardType;
    public string cardColor; 

    public Transform spawnPoint;
    private Vector2 initialPosition; //maybe have these set to spawn point game object so it's always the same?
    
    private Vector2 mousePosition; //mouse position coordinates 
    private float deltaX, deltaY;

    void Start()
    {
        initialPosition = spawnPoint.transform.position;
    }
    
    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

    }
    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }
    private void OnMouseUp()
    {
        transform.position = new Vector2(initialPosition.x, initialPosition.y);
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Monster")
        {
            MonsterScript monsterDetails = col.GetComponent<MonsterScript>();
            if(monsterDetails.color == cardColor && monsterDetails.ring == cardType)
            {
                monsterDetails.takeDamage();
                Destroy(gameObject);
            }
            
        }

    }
}
