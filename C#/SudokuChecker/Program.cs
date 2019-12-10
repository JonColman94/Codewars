using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuChecker
{
    class Sudoku
    {
        private readonly int[][] board;
        private readonly int boardWidth;
        private readonly int segmentWidth;

        public Sudoku(int[][] sudokuData)
        {
            board = sudokuData;
            boardWidth = sudokuData.Length;
            segmentWidth = (int)Math.Sqrt(boardWidth);
        }

        public bool IsValid()
        {
            return
                GetRows().All(IsComponentValid) &&
                GetColumns().All(IsComponentValid) &&
                GetSegments().All(IsComponentValid);
        }

        private IEnumerable<int> GetRow(int row)
        {
            return board[row];
        }

        private IEnumerable<int> GetColumn(int column)
        {
            return board.Select(row => row[column]);
        }

        private IEnumerable<int> GetSegment(int x, int y)
        {
            return board
                .Where((row, rowIndex) => rowIndex / segmentWidth == x)
                .SelectMany(row => row.Where((column, columnIndex) => columnIndex / segmentWidth == y));
        }

        private IEnumerable<IEnumerable<int>> GetRows()
        {
            return Enumerable.Range(0, boardWidth).Select(GetRow);
        }

        private IEnumerable<IEnumerable<int>> GetColumns()
        {
            return Enumerable.Range(0, boardWidth).Select(GetColumn);
        }

        private IEnumerable<IEnumerable<int>> GetSegments()
        {
            return Enumerable.Range(0, boardWidth).Select(index => GetSegment(index / segmentWidth, index % segmentWidth));
        }

        private bool IsComponentValid(IEnumerable<int> component)
        {
            return component.OrderBy(x => x).SequenceEqual(Enumerable.Range(1, boardWidth));
        }
    }
}
