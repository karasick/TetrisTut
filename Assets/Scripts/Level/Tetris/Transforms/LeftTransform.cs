//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LeftTransform : Transform
//{
//    public LeftTransform()
//    {

//    }

//    public override TransformState TransformState => TransformState.MoveLeft;

//    public override void TransformBlock(TetrisBlock tetrisBlock)
//    {
//        tetrisBlock.transform.position -= new Vector3(1, 0, 0);

//        if (TetrisGrid.IsValidGridPosition(tetrisBlock.transform))
//        {
//            TetrisGrid.UpdateTetrisGrid(tetrisBlock);
//        }
//        else
//        {
//            tetrisBlock.transform.position += new Vector3(1, 0, 0);
//        }
//    }
//}
