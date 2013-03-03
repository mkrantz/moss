using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MOSS
{
    /// <summary>Collection of data for each "Cell"</summary>
    public struct CellInfo
    {
        public int value;          // current value, 1-9, in cell    
        public List<int> candidates;   // list of possible values for cell
        public int innerRow;       // row number for inner square, 1-3
        public int innerCol;       // column number for inner square, 1-3
        public int outerRow;       // row number for entire puzzle, 1-9
        public int outerCol;       // column number for entire puzzle, 1-9
        public int squareNum;      // number of individual square that cell is a part of, 1-9
        public int squareCellNum;  // number of indiv. cell in indiv. square, 1-9
        
        //public CellInfo(int v, int[] c, int ir, int ic, int or, int oc) : this(v+c+ir+ic+or+oc){ }
        public CellInfo(int v, List<int> c, int ir, int ic, int or, int oc, int s, int sc)
        {
            value = v;
            candidates = c;
            innerRow = ir;
            innerCol = ic;
            outerRow = or;
            outerCol = oc;
            squareNum = s;
            squareCellNum = sc;
        }
    }


    static class Program
    {
        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSudoku());  
        }
    }



    // Full Sudoku puzzle, consisting of 9 "Sudoku Squares": 1 2 3
    //                                                       4 5 6
    //                                                       7 8 9
    public class SudokuBoard
    {

        #region Constructors

        public SudokuBoard() { }

        public SudokuBoard(SudokuSquare[] sudokuSquares)
        {
            _sudokuSquares = sudokuSquares;
        }

        #endregion


        #region Public attributes

        private SudokuSquare[] _sudokuSquares;
        public SudokuSquare[] sudokuSquares
        {
            get { return _sudokuSquares; }
            set { _sudokuSquares = value; }
        }

        #endregion

    }



    // Individual square, 9 of which form the entire puzzle, consisting of 9 "Cells": 1 2 3
    //                                                                                4 5 6
    //                                                                                7 8 9
    public class SudokuSquare
    {

        #region Constructors

        public SudokuSquare() { }   // let default to 0, indicating unpopulated
               
        public SudokuSquare(CellInfo[] cells)
        {
            _cells = cells;
        }

        /*public SudokuSquare(int[] valueArray)
        {
            _value1 = valueArray[0];
            _value2 = valueArray[1];
            _value3 = valueArray[2];
            _value4 = valueArray[3];
            _value5 = valueArray[4];
            _value6 = valueArray[5];
            _value7 = valueArray[6];
            _value8 = valueArray[7];
            _value9 = valueArray[8];
        }*/

        #endregion


        #region Public attributes

        private CellInfo[] _cells;
        public CellInfo[] cells
        {
            get { return _cells; }
            set { _cells = value; }
        }

        #endregion
           
    }
}

