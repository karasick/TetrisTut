using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    private LevelPanel levelPanel;

    public float fallSpeed = 1f;

    private float pushSpeed = 0.1f;
    private float levelSpeedAcceleration = 0.25f;
    private float fallTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        levelPanel = FindObjectOfType<LevelPanel>();
        fallSpeed = fallSpeed - (float)ScoreManager.speedLevel * levelSpeedAcceleration;
        InvokeRepeating("BlockFall", 0f, fallSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled && (Time.timeScale != 0))
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
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            RotateRight();
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


    public void MoveRight()
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


    public void MoveLeft()
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


    public void MoveUp()
    {
        transform.position += new Vector3(0, 1, 0);

        if (TetrisGrid.IsValidGridPosition(transform))
        {
            TetrisGrid.UpdateTetrisGrid(transform);
        }
        else
        {
            transform.position -= new Vector3(0, 1, 0);
        }
    }


    public void MoveDown()
    {
        transform.position -= new Vector3(0, 1, 0);

        if (TetrisGrid.IsValidGridPosition(transform))
        {
            TetrisGrid.UpdateTetrisGrid(transform);
        }
        else
        {
            transform.position += new Vector3(0, 1, 0);
        }
    }


    public void RotateRight()
    {
        transform.Rotate(new Vector3(0, 0, -90));

        foreach (Transform child in transform)
        {
            child.Rotate(new Vector3(0, 0, 90));
        }

        if (transform.eulerAngles.z == 270)
        {
            MoveUp();
        }
        else if (transform.eulerAngles.z == 180)
        {
            MoveRight();
        }
        else if (transform.eulerAngles.z == 90)
        {
            MoveDown();
        }
        else if (transform.eulerAngles.z == 0)
        {
            MoveLeft();
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

            if (transform.eulerAngles.z == 270)
            {
                MoveRight();
            }
            else if (transform.eulerAngles.z == 180)
            {
                MoveLeft();
            }
            else if (transform.eulerAngles.z == 90)
            {
                MoveUp();
            }
            else if (transform.eulerAngles.z == 0)
            {
                MoveDown();
            }
        }
    }
}
