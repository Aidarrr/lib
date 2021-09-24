package LeetcodeAugustChallenge;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class SudokuValidator {
    static final int fieldSize = 9;
    static final int boxSize = 3;
    List<Boolean> bitmask = new ArrayList<>(fieldSize + 1);

    public SudokuValidator(){
        for (int i = 0; i < fieldSize + 1; i++) {
            bitmask.add(false);
        }
    }

    public boolean isValidSudoku(char[][] board) {
        return isValidRows(board) && isValidColumns(board) && isValidBoxes(board);
    }

    public boolean isValidRows(char[][] board) {
        for (int i = 0; i < board.length; i++) {
            Collections.fill(bitmask, false);

            for (int j = 0; j < board.length; j++) {
                if (board[i][j] == '.')
                    continue;
                int num = Character.getNumericValue(board[i][j]);

                if (bitmask.get(num)) {
                    return false;
                } else {
                    bitmask.set(num, true);
                }
            }
        }

        return true;
    }

    public boolean isValidColumns(char[][] board) {
        for (int j = 0; j < board[0].length; j++) {
            Collections.fill(bitmask, Boolean.FALSE);

            for (int i = 0; i < board.length; i++) {
                if (board[i][j] == '.')
                    continue;
                int num = Character.getNumericValue(board[i][j]);

                if (bitmask.get(num)) {
                    return false;
                } else {
                    bitmask.set(num, true);
                }
            }
        }

        return true;
    }

    public boolean isValidBoxes(char[][] board) {
        for (int boxNum = 0; boxNum < fieldSize; boxNum++) {
            Collections.fill(bitmask, Boolean.FALSE);
            int startRow = (boxNum / boxSize) * boxSize, startCol = (boxNum % boxSize) * boxSize;

            for (int boxRow = startRow; boxRow < startRow + boxSize; boxRow++) {
                for (int boxCol = startCol; boxCol < startCol + boxSize; boxCol++) {
                    if (board[boxRow][boxCol] == '.')
                        continue;
                    int num = Character.getNumericValue(board[boxRow][boxCol]);

                    if (bitmask.get(num)) {
                        return false;
                    } else {
                        bitmask.set(num, true);
                    }
                }
            }
        }
        return true;
    }
}

public class ValidSudokuTask {
    public static void main(String[] args) {
        SudokuValidator sudokuValidator = new SudokuValidator();

        System.out.println(sudokuValidator.isValidSudoku(new char[][]{{'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                {'.', '.', '.', '.', '8', '.', '.', '7', '9'}}));

        System.out.println(sudokuValidator.isValidSudoku(new char[][]
                {{'8','3','.','.','7','.','.','.','.'}
                ,{'6','.','.','1','9','5','.','.','.'}
                ,{'.','9','8','.','.','.','.','6','.'}
                ,{'8','.','.','.','6','.','.','.','3'}
                ,{'4','.','.','8','.','3','.','.','1'}
                ,{'7','.','.','.','2','.','.','.','6'}
                ,{'.','6','.','.','.','.','2','8','.'}
                ,{'.','.','.','4','1','9','.','.','5'}
                ,{'.','.','.','.','8','.','.','7','9'}}));
    }
}
