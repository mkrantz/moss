using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MOSS
{
    public partial class frmSudoku : Form
    {
        public static List<int> possibleValues = new List<int>(9);  // will hold list of all possible cell values
        public SudokuBoard mySudoku;    // representation of Sudoku puzzle


        public frmSudoku()
        {
            InitializeComponent();
        }

        // Main program happenings go on here.
        private void frmSudoku_Load(object sender, EventArgs e)
        {
            possibleValues.AddRange(new int[] { 1,2,3,4,5,6,7,8,9 });

            // Enter the puzzle to solve in an easy graphical representation, per square
            // EASY
            //int[] square1 = { 0, 0, 0, 1, 0, 6, 3, 0, 0 };      //  1   2   3
            //int[] square2 = { 1, 5, 0, 0, 0, 0, 8, 6, 0 };      //  4   5   6
            //int[] square3 = { 0, 7, 0, 8, 2, 0, 0, 4, 0 };      //  7   8   9
            //int[] square4 = { 9, 0, 0, 0, 0, 4, 7, 3, 2 };
            //int[] square5 = { 4, 0, 0, 7, 0, 8, 0, 0, 6 };
            //int[] square6 = { 5, 6, 7, 3, 0, 0, 0, 0, 4 };
            //int[] square7 = { 0, 4, 0, 0, 1, 7, 0, 5, 0 };
            //int[] square8 = { 0, 8, 1, 0, 0, 0, 0, 3, 7 };
            //int[] square9 = { 0, 0, 9, 2, 0, 8, 0, 0, 0 };
            // MODERATE
            //int[] square1 = { 0, 0, 0, 0, 0, 9, 0, 0, 4 };      //  1   2   3
            //int[] square2 = { 2, 3, 5, 0, 0, 0, 0, 0, 0 };      //  4   5   6
            //int[] square3 = { 0, 0, 0, 7, 0, 1, 2, 0, 6 };      //  7   8   9
            //int[] square4 = { 0, 1, 0, 7, 5, 0, 0, 6, 0 };
            //int[] square5 = { 8, 0, 0, 1, 0, 6, 0, 0, 2 };
            //int[] square6 = { 0, 4, 0, 0, 9, 3, 0, 7, 0 };
            //int[] square7 = { 3, 0, 1, 8, 0, 7, 0, 0, 0 };
            //int[] square8 = { 0, 0, 0, 0, 0, 0, 4, 7, 1 };
            //int[] square9 = { 5, 0, 0, 9, 0, 0, 0, 0, 0 };
            // DIFFICULT
            //int[] square1 = { 0, 0, 1, 2, 5, 3, 0, 0, 0 };      //  1   2   3
            //int[] square2 = { 8, 0, 0, 0, 0, 0, 0, 0, 0 };      //  4   5   6
            //int[] square3 = { 7, 0, 0, 0, 0, 0, 6, 9, 5 };      //  7   8   9
            //int[] square4 = { 0, 0, 0, 3, 0, 7, 6, 0, 0 };
            //int[] square5 = { 1, 2, 0, 0, 0, 0, 0, 3, 8 };
            //int[] square6 = { 0, 0, 9, 8, 0, 4, 0, 0, 0 };
            //int[] square7 = { 8, 9, 4, 0, 0, 0, 0, 0, 2 };
            //int[] square8 = { 0, 0, 0, 0, 0, 0, 0, 0, 6 };
            //int[] square9 = { 0, 0, 0, 4, 3, 1, 9, 0, 0 };
            // VERY HARD
            int[] square1 = { 0, 6, 0, 0, 0, 0, 7, 0, 0 };      //  1   2   3
            int[] square2 = { 0, 5, 0, 3, 0, 0, 6, 0, 0 };      //  4   5   6
            int[] square3 = { 0, 2, 0, 0, 9, 0, 0, 1, 0 };      //  7   8   9
            int[] square4 = { 0, 0, 6, 0, 0, 4, 0, 0, 5 };
            int[] square5 = { 0, 3, 0, 0, 7, 0, 0, 9, 0 };
            int[] square6 = { 4, 0, 0, 1, 0, 0, 8, 0, 0 };
            int[] square7 = { 0, 4, 0, 0, 3, 0, 0, 2, 0 };
            int[] square8 = { 0, 0, 1, 0, 0, 8, 0, 4, 0 };
            int[] square9 = { 0, 0, 6, 0, 0, 0, 0, 5, 0 };

            SudokuSquare[] mySudokuSquares = new SudokuSquare[9];
            CellInfo[][] myCells = new CellInfo[9][];

            #region Build Cells and Squares
            // Build each cell and square
                //    value, candidates, inner row, inner col, outer row, outer col, square #, cell #
            myCells[0] = new CellInfo[] { new CellInfo(square1[0], new List<int>(possibleValues), 1, 1, 1, 1, 1  , 1),
                                            new CellInfo(square1[1], new List<int>(possibleValues), 1, 2, 1, 2, 1, 2),
                                            new CellInfo(square1[2], new List<int>(possibleValues), 1, 3, 1, 3, 1, 3),
                                            new CellInfo(square1[3], new List<int>(possibleValues), 2, 1, 2, 1, 1, 4),
                                            new CellInfo(square1[4], new List<int>(possibleValues), 2, 2, 2, 2, 1, 5),
                                            new CellInfo(square1[5], new List<int>(possibleValues), 2, 3, 2, 3, 1, 6),
                                            new CellInfo(square1[6], new List<int>(possibleValues), 3, 1, 3, 1, 1, 7),
                                            new CellInfo(square1[7], new List<int>(possibleValues), 3, 2, 3, 2, 1, 8),
                                            new CellInfo(square1[8], new List<int>(possibleValues), 3, 3, 3, 3, 1, 9) };
            mySudokuSquares[0] = new SudokuSquare(myCells[0]);

            myCells[1] = new CellInfo[] { new CellInfo(square2[0], new List<int>(possibleValues), 1, 1, 1, 4, 2  , 1),
                                            new CellInfo(square2[1], new List<int>(possibleValues), 1, 2, 1, 5, 2, 2),
                                            new CellInfo(square2[2], new List<int>(possibleValues), 1, 3, 1, 6, 2, 3),
                                            new CellInfo(square2[3], new List<int>(possibleValues), 2, 1, 2, 4, 2, 4),
                                            new CellInfo(square2[4], new List<int>(possibleValues), 2, 2, 2, 5, 2, 5),
                                            new CellInfo(square2[5], new List<int>(possibleValues), 2, 3, 2, 6, 2, 6),
                                            new CellInfo(square2[6], new List<int>(possibleValues), 3, 1, 3, 4, 2, 7),
                                            new CellInfo(square2[7], new List<int>(possibleValues), 3, 2, 3, 5, 2, 8),
                                            new CellInfo(square2[8], new List<int>(possibleValues), 3, 3, 3, 6, 2, 9) };
            mySudokuSquares[1] = new SudokuSquare(myCells[1]);

            myCells[2] = new CellInfo[] { new CellInfo(square3[0], new List<int>(possibleValues), 1, 1, 1, 7, 3  , 1),
                                            new CellInfo(square3[1], new List<int>(possibleValues), 1, 2, 1, 8, 3, 2),
                                            new CellInfo(square3[2], new List<int>(possibleValues), 1, 3, 1, 9, 3, 3),
                                            new CellInfo(square3[3], new List<int>(possibleValues), 2, 1, 2, 7, 3, 4),
                                            new CellInfo(square3[4], new List<int>(possibleValues), 2, 2, 2, 8, 3, 5),
                                            new CellInfo(square3[5], new List<int>(possibleValues), 2, 3, 2, 9, 3, 6),
                                            new CellInfo(square3[6], new List<int>(possibleValues), 3, 1, 3, 7, 3, 7),
                                            new CellInfo(square3[7], new List<int>(possibleValues), 3, 2, 3, 8, 3, 8),
                                            new CellInfo(square3[8], new List<int>(possibleValues), 3, 3, 3, 9, 3, 9) };
            mySudokuSquares[2] = new SudokuSquare(myCells[2]);

            myCells[3] = new CellInfo[] { new CellInfo(square4[0], new List<int>(possibleValues), 1, 1, 4, 1, 4  , 1),
                                            new CellInfo(square4[1], new List<int>(possibleValues), 1, 2, 4, 2, 4, 2),
                                            new CellInfo(square4[2], new List<int>(possibleValues), 1, 3, 4, 3, 4, 3),
                                            new CellInfo(square4[3], new List<int>(possibleValues), 2, 1, 5, 1, 4, 4),
                                            new CellInfo(square4[4], new List<int>(possibleValues), 2, 2, 5, 2, 4, 5),
                                            new CellInfo(square4[5], new List<int>(possibleValues), 2, 3, 5, 3, 4, 6),
                                            new CellInfo(square4[6], new List<int>(possibleValues), 3, 1, 6, 1, 4, 7),
                                            new CellInfo(square4[7], new List<int>(possibleValues), 3, 2, 6, 2, 4, 8),
                                            new CellInfo(square4[8], new List<int>(possibleValues), 3, 3, 6, 3, 4, 9) };
            mySudokuSquares[3] = new SudokuSquare(myCells[3]);

            myCells[4] = new CellInfo[] { new CellInfo(square5[0], new List<int>(possibleValues), 1, 1, 4, 4, 5  , 1),
                                            new CellInfo(square5[1], new List<int>(possibleValues), 1, 2, 4, 5, 5, 2),
                                            new CellInfo(square5[2], new List<int>(possibleValues), 1, 3, 4, 6, 5, 3),
                                            new CellInfo(square5[3], new List<int>(possibleValues), 2, 1, 5, 4, 5, 4),
                                            new CellInfo(square5[4], new List<int>(possibleValues), 2, 2, 5, 5, 5, 5),
                                            new CellInfo(square5[5], new List<int>(possibleValues), 2, 3, 5, 6, 5, 6),
                                            new CellInfo(square5[6], new List<int>(possibleValues), 3, 1, 6, 4, 5, 7),
                                            new CellInfo(square5[7], new List<int>(possibleValues), 3, 2, 6, 5, 5, 8),
                                            new CellInfo(square5[8], new List<int>(possibleValues), 3, 3, 6, 6, 5, 9) };
            mySudokuSquares[4] = new SudokuSquare(myCells[4]);

            myCells[5] = new CellInfo[] { new CellInfo(square6[0], new List<int>(possibleValues), 1, 1, 4, 7, 6  , 1),
                                            new CellInfo(square6[1], new List<int>(possibleValues), 1, 2, 4, 8, 6, 2),
                                            new CellInfo(square6[2], new List<int>(possibleValues), 1, 3, 4, 9, 6, 3),
                                            new CellInfo(square6[3], new List<int>(possibleValues), 2, 1, 5, 7, 6, 4),
                                            new CellInfo(square6[4], new List<int>(possibleValues), 2, 2, 5, 8, 6, 5),
                                            new CellInfo(square6[5], new List<int>(possibleValues), 2, 3, 5, 9, 6, 6),
                                            new CellInfo(square6[6], new List<int>(possibleValues), 3, 1, 6, 7, 6, 7),
                                            new CellInfo(square6[7], new List<int>(possibleValues), 3, 2, 6, 8, 6, 8),
                                            new CellInfo(square6[8], new List<int>(possibleValues), 3, 3, 6, 9, 6, 9) };
            mySudokuSquares[5] = new SudokuSquare(myCells[5]);

            myCells[6] = new CellInfo[] { new CellInfo(square7[0], new List<int>(possibleValues), 1, 1, 7, 1, 7  , 1),
                                            new CellInfo(square7[1], new List<int>(possibleValues), 1, 2, 7, 2, 7, 2),
                                            new CellInfo(square7[2], new List<int>(possibleValues), 1, 3, 7, 3, 7, 3),
                                            new CellInfo(square7[3], new List<int>(possibleValues), 2, 1, 8, 1, 7, 4),
                                            new CellInfo(square7[4], new List<int>(possibleValues), 2, 2, 8, 2, 7, 5),
                                            new CellInfo(square7[5], new List<int>(possibleValues), 2, 3, 8, 3, 7, 6),
                                            new CellInfo(square7[6], new List<int>(possibleValues), 3, 1, 9, 1, 7, 7),
                                            new CellInfo(square7[7], new List<int>(possibleValues), 3, 2, 9, 2, 7, 8),
                                            new CellInfo(square7[8], new List<int>(possibleValues), 3, 3, 9, 3, 7, 9) };
            mySudokuSquares[6] = new SudokuSquare(myCells[6]);

            myCells[7] = new CellInfo[] { new CellInfo(square8[0], new List<int>(possibleValues), 1, 1, 7, 4, 8  , 1),
                                            new CellInfo(square8[1], new List<int>(possibleValues), 1, 2, 7, 5, 8, 2),
                                            new CellInfo(square8[2], new List<int>(possibleValues), 1, 3, 7, 6, 8, 3),
                                            new CellInfo(square8[3], new List<int>(possibleValues), 2, 1, 8, 4, 8, 4),
                                            new CellInfo(square8[4], new List<int>(possibleValues), 2, 2, 8, 5, 8, 5),
                                            new CellInfo(square8[5], new List<int>(possibleValues), 2, 3, 8, 6, 8, 6),
                                            new CellInfo(square8[6], new List<int>(possibleValues), 3, 1, 9, 4, 8, 7),
                                            new CellInfo(square8[7], new List<int>(possibleValues), 3, 2, 9, 5, 8, 8),
                                            new CellInfo(square8[8], new List<int>(possibleValues), 3, 3, 9, 6, 8, 9) };
            mySudokuSquares[7] = new SudokuSquare(myCells[7]);

            myCells[8] = new CellInfo[] { new CellInfo(square9[0], new List<int>(possibleValues), 1, 1, 7, 7, 9  , 1),
                                            new CellInfo(square9[1], new List<int>(possibleValues), 1, 2, 7, 8, 9, 2),
                                            new CellInfo(square9[2], new List<int>(possibleValues), 1, 3, 7, 9, 9, 3),
                                            new CellInfo(square9[3], new List<int>(possibleValues), 2, 1, 8, 7, 9, 4),
                                            new CellInfo(square9[4], new List<int>(possibleValues), 2, 2, 8, 8, 9, 5),
                                            new CellInfo(square9[5], new List<int>(possibleValues), 2, 3, 8, 9, 9, 6),
                                            new CellInfo(square9[6], new List<int>(possibleValues), 3, 1, 9, 7, 9, 7),
                                            new CellInfo(square9[7], new List<int>(possibleValues), 3, 2, 9, 8, 9, 8),
                                            new CellInfo(square9[8], new List<int>(possibleValues), 3, 3, 9, 9, 9, 9) };
            mySudokuSquares[8] = new SudokuSquare(myCells[8]);
            #endregion

            mySudoku = new SudokuBoard(mySudokuSquares);

            #region old constuctors
            /*SudokuBoard mySudoku = new SudokuBoard(new SudokuSquare(square1),
                                                    new SudokuSquare(square2),
                                                    new SudokuSquare(square3),
                                                    new SudokuSquare(square4),
                                                    new SudokuSquare(square5),
                                                    new SudokuSquare(square6),
                                                    new SudokuSquare(square7),
                                                    new SudokuSquare(square8),
                                                    new SudokuSquare(square9));*/

            /*SudokuBoard mySudoku = new SudokuBoard(new SudokuSquare(0, 0, 0, 1, 0, 6, 3, 0, 0),
                                                   new SudokuSquare(1, 5, 0, 0, 0, 0, 8, 6, 0),
                                                   new SudokuSquare(0, 7, 0, 8, 2, 0, 0, 4, 0),
                                                   new SudokuSquare(9, 0, 0, 0, 0, 4, 7, 3, 2),
                                                   new SudokuSquare(4, 0, 0, 7, 0, 8, 0, 0, 6),
                                                   new SudokuSquare(5, 6, 7, 3, 0, 0, 0, 0, 4),
                                                   new SudokuSquare(0, 4, 0, 0, 1, 7, 0, 5, 0),
                                                   new SudokuSquare(0, 8, 1, 0, 0, 0, 0, 3, 7),
                                                   new SudokuSquare(0, 0, 9, 2, 0, 8, 0, 0, 0));*/
            #endregion

            // Setup columns of display grid
            sudokuGrid.ColumnCount = 9;
            //sudokuGrid.Columns[0].Name = "c1";

            // Setup rows of display grid with contents of defined puzzle
            string[] row0 = { square1[0].ToString(), square1[1].ToString(), square1[2].ToString(), square2[0].ToString(), square2[1].ToString(), square2[2].ToString(), square3[0].ToString(), square3[1].ToString(), square3[2].ToString() };
            string[] row1 = { square1[3].ToString(), square1[4].ToString(), square1[5].ToString(), square2[3].ToString(), square2[4].ToString(), square2[5].ToString(), square3[3].ToString(), square3[4].ToString(), square3[5].ToString() };
            string[] row2 = { square1[6].ToString(), square1[7].ToString(), square1[8].ToString(), square2[6].ToString(), square2[7].ToString(), square2[8].ToString(), square3[6].ToString(), square3[7].ToString(), square3[8].ToString() };
            string[] row3 = { square4[0].ToString(), square4[1].ToString(), square4[2].ToString(), square5[0].ToString(), square5[1].ToString(), square5[2].ToString(), square6[0].ToString(), square6[1].ToString(), square6[2].ToString() };
            string[] row4 = { square4[3].ToString(), square4[4].ToString(), square4[5].ToString(), square5[3].ToString(), square5[4].ToString(), square5[5].ToString(), square6[3].ToString(), square6[4].ToString(), square6[5].ToString() };
            string[] row5 = { square4[6].ToString(), square4[7].ToString(), square4[8].ToString(), square5[6].ToString(), square5[7].ToString(), square5[8].ToString(), square6[6].ToString(), square6[7].ToString(), square6[8].ToString() };
            string[] row6 = { square7[0].ToString(), square7[1].ToString(), square7[2].ToString(), square8[0].ToString(), square8[1].ToString(), square8[2].ToString(), square9[0].ToString(), square9[1].ToString(), square9[2].ToString() };
            string[] row7 = { square7[3].ToString(), square7[4].ToString(), square7[5].ToString(), square8[3].ToString(), square8[4].ToString(), square8[5].ToString(), square9[3].ToString(), square9[4].ToString(), square9[5].ToString() };
            string[] row8 = { square7[6].ToString(), square7[7].ToString(), square7[8].ToString(), square8[6].ToString(), square8[7].ToString(), square8[8].ToString(), square9[6].ToString(), square9[7].ToString(), square9[8].ToString() };

            sudokuGrid.Rows.Add(zerosToEmpties(row0));
            sudokuGrid.Rows.Add(zerosToEmpties(row1));
            sudokuGrid.Rows.Add(zerosToEmpties(row2));
            sudokuGrid.Rows.Add(zerosToEmpties(row3));
            sudokuGrid.Rows.Add(zerosToEmpties(row4));
            sudokuGrid.Rows.Add(zerosToEmpties(row5));
            sudokuGrid.Rows.Add(zerosToEmpties(row6));
            sudokuGrid.Rows.Add(zerosToEmpties(row7));
            sudokuGrid.Rows.Add(zerosToEmpties(row8));

            // Pretty-up cells
            differentiateInternalSquares();
            highlightNonEmptyCells();

            lblCandidates.Visible = false;
            lbCandidates.Visible = false;
        }


        private void btnSolve_Click(object sender, EventArgs e)
        {
            // Solve the puzzle
            bool solved = solvePuzzle(ref mySudoku); 

            if(solved)
            {
                // Display solved puzzle 
                drawPuzzle(mySudoku);
                lblResults.Text = "I was able to solve this for you!  See above.";

            }
            else
            {
                // I suck
                // Display non/partially solved puzzle 
                drawPuzzle(mySudoku);
                lblResults.Text = "I was not able to solve this for you.  I'm sorry.  Above is what I have so far.  Hover over empty cells to see candidates.";
                lblCandidates.Visible = true;
                lbCandidates.Visible = true;
            }
        }


        private bool solvePuzzle(ref SudokuBoard mySudoku)
        {

            traverseAndCrossHatch(ref mySudoku);
            //traverseAndGetSingleSquareCandidates(mySudoku);
            //traverseAndNumberClaim(mySudoku);
            //traverseAndSolvePairs(mySudoku);
            //traverseAndSolveTriples(mySudoku);

            return isSolved(mySudoku);
        }

        


        private void traverseAndCrossHatch(ref SudokuBoard mySudoku)
        {
            SudokuSquare currSquare;
            CellInfo currCell;
            bool cellWasSolved = true;
            int pass = 0;

            while(cellWasSolved)
            {
                pass++;
                cellWasSolved = false; // start out with nothing solved this time around
                for(int i = 0; i < 9; i++)  // loop through each square
                {
                    for(int j = 0; j < 9; j++)  // loop through each cell within square
                    {
                        currSquare = mySudoku.sudokuSquares[i];
                        currCell = currSquare.cells[j];

                        if(currCell.value == 0)    // assign candidates and try to get value
                        {
                            assignCandidatesFromSquare(currSquare, ref currCell);
                            assignCandidatesFromRow(mySudoku, ref currCell);
                            assignCandidatesFromCol(mySudoku, ref currCell);

                            if(currCell.candidates.Count == 1)
                            {
                                inspectCandidatesAndAssignValue(ref currCell);
                                mySudoku.sudokuSquares[i].cells[j] = currCell;  // write back to main puzzle
                                cellWasSolved = true;
                            }

                        }
                    }
                }
            }
        }

        
        private void assignCandidatesFromSquare(SudokuSquare currSquare, ref CellInfo currCell)
        {
            int currValue;

            for(int i = 0; i < 9; i++)  // traverse through square
            {
                currValue = currSquare.cells[i].value;
                if(currValue != 0 && currValue != currCell.value)
                {
                    currCell.candidates.Remove(currValue);
                }
            }
        }


        private void assignCandidatesFromRow(SudokuBoard mySudoku, ref CellInfo currCell)
        {
            List<CellInfo> currRow = getRow(mySudoku, currCell);
            int currValue;

            foreach (CellInfo cell in currRow)
            {
                currValue = cell.value;
                if(currValue != 0 && currValue != currCell.value)
                {
                    currCell.candidates.Remove(currValue);
                }
            }
        }


        /// <summary>
        /// Returns a collection of all cells in the passed-in cell's outer row.
        /// </summary>
        /// <param name="mySudoku"></param>
        /// <param name="targetCell"></param>
        /// <returns></returns>
        private List<CellInfo> getRow(SudokuBoard mySudoku, CellInfo targetCell)
        {
            CellInfo currCell;
            List<CellInfo> toReturn = new List<CellInfo>();

            for(int i = 0; i < 9; i++)  // loop through each square
            {
                for(int j = 0; j < 9; j++)  // loop through each cell within square
                {
                    currCell = mySudoku.sudokuSquares[i].cells[j];

                    if(currCell.outerRow == targetCell.outerRow)    // belongs to same row as targetCell
                    {
                        toReturn.Add(currCell);
                    }

                }
            }

            return toReturn;
        }


        private void assignCandidatesFromCol(SudokuBoard mySudoku, ref CellInfo currCell)
        {
            List<CellInfo> currCol = getColumn(mySudoku, currCell);
            int currValue;

            foreach(CellInfo cell in currCol)
            {
                currValue = cell.value;
                if(currValue != 0 && currValue != currCell.value)
                {
                    currCell.candidates.Remove(currValue);
                }
            }
        }


        /// <summary>
        /// Returns a collection of all cells in the passed-in cell's outer column.
        /// </summary>
        /// <param name="mySudoku"></param>
        /// <param name="targetCell"></param>
        /// <returns></returns>
        private List<CellInfo> getColumn(SudokuBoard mySudoku, CellInfo targetCell)
        {
            CellInfo currCell;
            List<CellInfo> toReturn = new List<CellInfo>();

            for(int i = 0; i < 9; i++)  // loop through each square
            {
                for(int j = 0; j < 9; j++)  // loop through each cell within square
                {
                    currCell = mySudoku.sudokuSquares[i].cells[j];

                    if(currCell.outerCol == targetCell.outerCol)    // belongs to same column as targetCell
                    {
                        toReturn.Add(currCell);
                    }
                }
            }

            return toReturn;
        }


        private void inspectCandidatesAndAssignValue(ref CellInfo currCell)
        {
            if(currCell.candidates.Count == 1)  // must ensure this is the case
            {
                currCell.value = currCell.candidates.Find(new Predicate<int>(notEqualToZero));
            }
        }


        private static bool notEqualToZero(int i)
        {
            return (i != 0);
        }


        private bool isSolved(SudokuBoard mySudoku)
        {
            bool solved = true;

            for(int i = 0; i < 9; i++)  // loop through each square
            {
                for(int j = 0; j < 9; j++)  // loop through each cell within square
                {
                    if(mySudoku.sudokuSquares[i].cells[j].value == 0)
                    {
                        solved = false;
                    }
                }
            }

            return solved;
        }


        /// <summary>
        /// Returns a collection of all cells in the passed-in outer row number.
        /// </summary>
        /// <param name="mySudoku"></param>
        /// <param name="desiredRow"></param>
        /// <returns></returns>
        private List<CellInfo> getRow(SudokuBoard mySudoku, int desiredRow)
        {
            CellInfo currCell;
            List<CellInfo> toReturn = new List<CellInfo>();

            for(int i = 0; i < 9; i++)  // loop through each square
            {
                for(int j = 0; j < 9; j++)  // loop through each cell within square
                {
                    currCell = mySudoku.sudokuSquares[i].cells[j];

                    if(currCell.outerRow == desiredRow)    // belongs to row desiredRow
                    {
                        toReturn.Add(currCell);
                    }

                }
            }

            return toReturn;
        }


        /// <summary>
        /// Returns a collection of values of cells in the passed-in outer row number.
        /// </summary>
        /// <param name="mySudoku"></param>
        /// <param name="desiredRow"></param>
        /// <returns></returns>
        private List<string> getRowValues(SudokuBoard mySudoku, int desiredRow)
        {
            CellInfo currCell;
            List<string> toReturn = new List<string>();

            for(int i = 0; i < 9; i++)  // loop through each square
            {
                for(int j = 0; j < 9; j++)  // loop through each cell within square
                {
                    currCell = mySudoku.sudokuSquares[i].cells[j];

                    if(currCell.outerRow == desiredRow)    // belongs to row desiredRow
                    {
                        toReturn.Add(currCell.value.ToString());
                    }

                }
            }

            return toReturn;
        }


        private void highlightNonEmptyCells()
        {
            for(int i = 0; i < 9; i++) 
            {
                for(int j = 0; j < 9; j++) 
                {
                    if ((string)sudokuGrid.Rows[i].Cells[j].Value != "")    // has a value
                    {
                        //sudokuGrid.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                        sudokuGrid.Rows[i].Cells[j].Style.Font = new Font("Arial", 10, FontStyle.Bold);;
                    }
                }
            }
        }


        private void drawPuzzle(SudokuBoard mySudoku)
        {
            // Setup rows of display grid with contents of puzzle, as exists in mySudoku
            List<string> row1 = getRowValues(mySudoku, 1);
            List<string> row2 = getRowValues(mySudoku, 2);
            List<string> row3 = getRowValues(mySudoku, 3);
            List<string> row4 = getRowValues(mySudoku, 4);
            List<string> row5 = getRowValues(mySudoku, 5);
            List<string> row6 = getRowValues(mySudoku, 6);
            List<string> row7 = getRowValues(mySudoku, 7);
            List<string> row8 = getRowValues(mySudoku, 8);
            List<string> row9 = getRowValues(mySudoku, 9);

            sudokuGrid.Rows.Clear();
            sudokuGrid.Rows.Add(zerosToEmpties(row1.ToArray()));
            sudokuGrid.Rows.Add(zerosToEmpties(row2.ToArray()));
            sudokuGrid.Rows.Add(zerosToEmpties(row3.ToArray()));
            sudokuGrid.Rows.Add(zerosToEmpties(row4.ToArray()));
            sudokuGrid.Rows.Add(zerosToEmpties(row5.ToArray()));
            sudokuGrid.Rows.Add(zerosToEmpties(row6.ToArray()));
            sudokuGrid.Rows.Add(zerosToEmpties(row7.ToArray()));
            sudokuGrid.Rows.Add(zerosToEmpties(row8.ToArray()));
            sudokuGrid.Rows.Add(zerosToEmpties(row9.ToArray()));

            differentiateInternalSquares();
            highlightNonEmptyCells();
        }


        private void differentiateInternalSquares()
        {
            //DataGridViewAdvancedBorderStyle borderThickRight = new DataGridViewAdvancedBorderStyle();
            //borderThickRight.Right = DataGridViewAdvancedCellBorderStyle.None;
            //DataGridViewAdvancedBorderStyle borderThickBottom = new DataGridViewAdvancedBorderStyle();           
            //borderThickBottom.Bottom = DataGridViewAdvancedCellBorderStyle.OutsetDouble;

            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(convertCoordsToSquareNumber(i,j) % 2 == 0)  // needs to be special
                    {
                        //sudokuGrid.Rows[i].Cells[j].Style.Font = myFont;
                        //sudokuGrid.Rows[i].Cells[j].Style.ForeColor = Color.Maroon;
                        sudokuGrid.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                        //sudokuGrid.Rows[i].Cells[j].AdjustCellBorderStyle(borderThickBottom,  null, false, false, false, false);
                        //sudokuGrid.Rows[0].Cells[0].AdjustCellBorderStyle(new DataGridViewAdvancedCellBorderStyle());
                    }

                }
            }
        }


        private int convertCoordsToSquareNumber(int k, int l)
        {
            int to_return = 0;

            for(int i = 0; i < 9; i++)  // loop through each square
            {
                for(int j = 0; j < 9; j++)  // loop through each cell within square
                {
                    if (mySudoku.sudokuSquares[i].cells[j].outerRow == k + 1
                        && mySudoku.sudokuSquares[i].cells[j].outerCol == l + 1)
                    {
                        to_return = mySudoku.sudokuSquares[i].cells[j].squareNum;
                        break;
                    }
                }
                if(to_return != 0)
                    break;
            }

            return to_return;
        }


        private int convertCoordsToCellNumber(int k, int l)
        {
            int to_return = 0;

            for(int i = 0; i < 9; i++)  // loop through each square
            {
                for(int j = 0; j < 9; j++)  // loop through each cell within square
                {
                    if(mySudoku.sudokuSquares[i].cells[j].outerRow == k + 1
                        && mySudoku.sudokuSquares[i].cells[j].outerCol == l + 1)
                    {
                        to_return = mySudoku.sudokuSquares[i].cells[j].squareCellNum;
                        break;
                    }
                }
                if(to_return != 0)
                    break;
            }

            return to_return;
        }


        private string[] zerosToEmpties(string[] p)
        {
            for(int i = 0; i < p.Length; i++)
            {
                if(p[i] == "0")
                    p[i] = "";
            }
            return p;
        }


        private void sudokuGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // show a list of candidates for the current cell, if not already assigned a value
            List<int> candidates;
            int currSquareNumber;
            int currCellNumber;

            currSquareNumber = convertCoordsToSquareNumber(e.RowIndex, e.ColumnIndex);
            currCellNumber = convertCoordsToCellNumber(e.RowIndex, e.ColumnIndex);

            if(mySudoku.sudokuSquares[currSquareNumber - 1].cells[currCellNumber - 1].value == 0)
            {
                candidates = mySudoku.sudokuSquares[currSquareNumber - 1].cells[currCellNumber - 1].candidates;
                candidates.Sort();

                foreach(int candidate in candidates)
                {
                    lbCandidates.Items.Add(candidate);
                }

                lblCandidates.Visible = true;
                lbCandidates.Visible = true;
            }
        }


        private void sudokuGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            lbCandidates.Items.Clear();

            lblCandidates.Visible = false;
            lbCandidates.Visible = false;
        }

       

        

    }
}