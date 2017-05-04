using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserStack {
    private class Node
    {
        LaserRay laser;
        Node next;

        public Node(LaserRay laser)
        {
            this.laser = laser;
            this.next = null;
        }

        public void SetNext(Node next)
        {
            this.next = next;
        }

        public LaserRay GetLaser()
        {
            return laser;
        }

        public Node GetNext()
        {
            return next;
        }
    }

    private Node head;
    private int count;
    
    public LaserStack()
    {
        count = 0;
    }

    public void push(LaserRay laser)
    {
        //laser.transform.position = new Vector3(0.0f, 150.0f, 0.0f);
        //laser.transform.GetComponent<LineRenderer>().SetPosition(1, laser.transform.position);
        laser.gameObject.SetActive(false);
        laser.onStack = true;
        if (head == null) { head = new Node(laser); return; }
        Node newNode = new Node(laser);
        newNode.SetNext(head);
        head = newNode;
        count++;        
    }

    public LaserRay pop()
    {
        LaserRay laser = head.GetLaser();
        head = head.GetNext();
        laser.onStack = false;
        count--;
        laser.gameObject.SetActive(true);        
        return laser;
    }

    public int size()
    {
        return count;
    }
}
