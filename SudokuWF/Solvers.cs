using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuWF
{
    public class Solvers
    {
        private static int BOARD_SIZE = 9;

        public static int[,] SolveBoard(int[,] receivedBoard)
        {
            Models.Counter counterInstance = new Models.Counter();
           
            
            int[,] board = receivedBoard;

            try
            {
                List<Cell> EmptyCells = new List<Cell>();
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
                                validMoves = FindValidMoves(board, y, i),
                                CountValuesPreviouslyTried = 0
                            });
                        }
                    }
                }
                EmptyCells = EmptyCells.OrderBy(i => i.validMoves.Count()).ToList();

                while (!ValidateSolution(board))
                {
                    Cell cell = EmptyCells[counterInstance.getCounter()];
                    if (board[cell.row, cell.column] != 0) { board[cell.row, cell.column] = 0; }

                    List<int> validMoves = FindValidMoves(board, cell.row, cell.column);

                    if (validMoves.Count == 0 || validMoves.Count == cell.CountValuesPreviouslyTried)
                    {
                        var obj = EmptyCells.FirstOrDefault(e => e.row == cell.row && e.column == cell.column);
                        obj.CountValuesPreviouslyTried = 0;
                        counterInstance.decrementCounter();
                    }
                    else
                    {
                        board[cell.row, cell.column] = validMoves[cell.CountValuesPreviouslyTried];

                        var obj = EmptyCells.FirstOrDefault(e => e.row == cell.row && e.column == cell.column);
                        if (obj != null)
                        {
                            obj.value = validMoves[cell.CountValuesPreviouslyTried];
                            obj.CountValuesPreviouslyTried = obj.CountValuesPreviouslyTried + 1;
                        }
                        counterInstance.incrementCounter();
                    }
                }
            }
            catch (Exception e)
            {
                //unsolvable
            }

            return board;
        }


        public static bool ValidateSolution(int[,] board)
        {
            //check rows and columns 
            for (int i = 0; i < board.GetLength(0); i++)
            {
                //check row
                int[] rowValues = Enumerable.Range(0, board.GetLength(1)).Select(row => board[i, row]).ToArray();
                if (rowValues.Where(e => e >= 1 && e <= BOARD_SIZE).Distinct().Count() != BOARD_SIZE || rowValues.Contains(0)) { return false; }
                else
                {
                    //check column
                    int[] columnVals = Enumerable.Range(0, board.GetLength(0)).Select(column => board[column, i]).ToArray();
                    if (columnVals.Where(e => e >= 1 && e <= BOARD_SIZE).Distinct().Count() != BOARD_SIZE || columnVals.Contains(0)) { return false; }
                }
            }

            //check the 3x3 blocks
            for (int o = 0; o < board.GetLength(0); o = o + 3)
            {
                for (int l = 0; l < board.GetLength(0); l = l + 3)
                {
                    List<int> threeXthree = new List<int>();
                    for (int t = 0; t < 3; t++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            threeXthree.Add(board[t + l, m + o]);
                        }
                    }
                    if (threeXthree.Where(e => e >= 1 && e <= BOARD_SIZE).Distinct().Count() != BOARD_SIZE) { return false; }
                }
            }
            return true;
        }


        public static bool SolvableBoard(int[,] board)
        {
            //check rows and columns 
            for (int i = 0; i < board.GetLength(0); i++)
            {
                //check row
                int[] rowValues = Enumerable.Range(0, board.GetLength(1)).Select(row => board[i, row]).ToArray();
                if (rowValues.Where(e => e != 0).Distinct().Count() != rowValues.Count(e => e != 0)) { return false; }
                else
                {
                    //check column
                    int[] columnVals = Enumerable.Range(0, board.GetLength(0)).Select(column => board[column, i]).ToArray();
                    if (columnVals.Where(e => e != 0).Distinct().Count() != columnVals.Count(e => e != 0)) { return false; }
                }
            }

            //check the 3x3 blocks
            for (int o = 0; o < board.GetLength(0); o = o + 3)
            {
                for (int l = 0; l < board.GetLength(0); l = l + 3)
                {
                    List<int> threeXthree = new List<int>();
                    for (int t = 0; t < 3; t++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            threeXthree.Add(board[t + l, m + o]);
                        }
                    }
                    if (threeXthree.Where(e => e != 0).Distinct().Count() != threeXthree.Count(e => e != 0)) { return false; }
                }
            }

            return true;
        }


        public static List<int> FindValidMoves(int[,] board, int row, int col)
        {
            int[] columnValues = Enumerable.Range(0, board.GetLength(0)).Select(x => board[x, col]).ToArray();
            int[] rowValues = Enumerable.Range(0, board.GetLength(1)).Select(x => board[row, x]).ToArray();
            List<int> threeXthreeValues = new List<int>();

            //get 3x3 block the coordinate belongs to
            //check the 3x3 blocks
            int threeXthreeRow = (row / 3) * 3;
            int threeXthreeColumn = (col / 3) * 3;

            for (int o = threeXthreeRow; o < 3 + threeXthreeRow; o++)
            {
                for (int p = threeXthreeColumn; p < 3 + threeXthreeColumn; p++)
                {
                    threeXthreeValues.Add(board[o, p]);
                }
            }

            List<int> validNumbers = Enumerable.Range(1, board.GetLength(0)).Where(x => !columnValues.Contains(x) && !rowValues.Contains(x) && !threeXthreeValues.Contains(x)).ToList();

            return validNumbers;
        }
    }
}
