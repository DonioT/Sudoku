using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWF
{
    public class Generators
    {
        private static int BOARD_SIZE = 9;
        public static List<int[,]> GenerateRandomPuzzle()
        {
            int[,] board = new int[BOARD_SIZE, BOARD_SIZE];

            Random num = new Random();

            List<Cell> EmptyCells = new List<Cell>();
            List<Cell> Addedcells = new List<Cell>();
            for (int i = 0; i < board.GetLength(1); i++)
            {
                for (int y = 0; y < board.GetLength(0); y++)
                {
                    if (board[y, i] == 0)
                    {
                        EmptyCells.Add(new Cell
                        {
                            column = i,
                            row = y,
                            value = 0,
                        });
                    }
                }
            }
            while (Addedcells.Count < 18 && Addedcells.Select(e => e.value).Distinct().Count() < 9)
            {

                var randomCell = EmptyCells[num.Next(EmptyCells.Count)];
                var randomCellMoves = Solvers.FindValidMoves(board, randomCell.row, randomCell.column);

                if (randomCellMoves.Count == 0)
                {
                    GenerateRandomPuzzle();
                }
                else
                {
                    var randomValue = randomCellMoves[num.Next(randomCellMoves.Count())];
                    board[randomCell.row, randomCell.column] = randomValue;
                    randomCell.value = randomValue;
                    Addedcells.Add(randomCell);
                    EmptyCells.Remove(randomCell);
                }
            }
            List<int[,]> returnBoards = new List<int[,]>();
            returnBoards.Add((int[,])board.Clone());
            int[,] solvedBoard = Solvers.SolveBoard(board);
            returnBoards.Add((int[,])solvedBoard.Clone());

      
            return returnBoards;
        }

    }
}
