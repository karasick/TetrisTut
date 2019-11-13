using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    public float fallSpeed = 1f;

    private float pushSpeed = 0.1f;
    private float fallTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        fallSpeed = fallSpeed - (float)ScoreManager.speedLevel / 10;
        InvokeRepeating("BlockFall", 0f, fallSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled)
        {
            CheckUserInput();

            fallTime = Time.time;
        }
    }

    private void BlockFall()
    {
        transform.position -= new Vector3(0, 1, 0);

        if (TetrisGrid.IsValidGridPosition(transform))
        {
            TetrisGrid.UpdateTetrisGrid(transform);
        }
        else
        {
            transform.position += new Vector3(0, 1, 0);
            CancelInvoke("BlockFall");

            TetrisGrid.DeleteRows();

            FindObjectOfType<TetrisBlockSpawner>().SpawnRandom();

            enabled = false;
        }
    }

    private void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);

            if (TetrisGrid.IsValidGridPosition(transform))
            {
                TetrisGrid.UpdateTetrisGrid(transform);
            }
            else
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= new Vector3(1, 0, 0);

            if (TetrisGrid.IsValidGridPosition(transform))
            {
                TetrisGrid.UpdateTetrisGrid(transform);
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(new Vector3(0, 0, -90));

            foreach (Transform child in transform)
            {
                child.Rotate(new Vector3(0, 0, 90));
            }

            if (TetrisGrid.IsValidGridPosition(transform))
            {
                TetrisGrid.UpdateTetrisGrid(transform);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 90));

                foreach (Transform child in transform)
                {
                    child.Rotate(new Vector3(0, 0, -90));
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            CancelInvoke("BlockFall");
            InvokeRepeating("BlockFall", 0f, pushSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            CancelInvoke("BlockFall");
            InvokeRepeating("BlockFall", 0f, fallSpeed);
        }
    }
}
