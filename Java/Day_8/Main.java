package Day8;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {
	static String colourStart = "\u001B[";

	static enum Direction {
		UP, DOWN, RIGHT, LEFT
	};

	public static void main(String[] args) {
		ArrayList<ArrayList<Integer>> Forest = new ArrayList<ArrayList<Integer>>();
		Scanner InputReader;

		try {
			File inputFile = new File("Day_8/Files/input.txt");
			inputFile.setReadOnly();

			InputReader = new Scanner(inputFile);
		} catch (FileNotFoundException e) {
			System.out.println(String.format("%s31m", colourStart) + "An error occurred");
			e.printStackTrace();
			System.out.println(String.format("%s37m", colourStart));
			return;
		}

		while (InputReader.hasNextLine()) {
			ArrayList<Integer> TreeRow = new ArrayList<>();
			String Line = InputReader.nextLine();

			for (char Tree : Line.toCharArray()) {
				int TreeHeight = Tree - '0';
				TreeRow.add(TreeHeight);
			}

			Forest.add(TreeRow);
		}

		// part1(Forest);
		part2(Forest);

		InputReader.close();
	}

	public static void part1(ArrayList<ArrayList<Integer>> Forest) {
		int results = 0;

		for (int i = 0; i < Forest.size(); i++) {
			ArrayList<Integer> TreeRow = Forest.get(i);
			for (int c = 0; c < Forest.get(i).size(); c++) {
				int Tree = TreeRow.get(c);
				for (Direction direction : Direction.values()) {
					int[] CurrPosition = new int[] { i, c };
					if (checkLine(Forest, CurrPosition, CurrPosition, Tree, direction)) {
						results++;
						break;
					}
				}
			}
		}
		System.out.println(String.format("There are %d trees you can see.", results));
	}

	public static boolean checkLine(ArrayList<ArrayList<Integer>> Forest, int[] Position, int[] OriginalPosition,
			int OriginalHeight, Direction direction) {
		int Row = Position[0];
		int Column = Position[1];
		int CurrentTreeHeight = Forest.get(Row).get(Column);

		int[] NewPosition = Position.clone();

		// ArrayList<Integer> ForestRow = Forest.get(Column)
		if (Row != OriginalPosition[0] ^ Column != OriginalPosition[1]) {
			if (CurrentTreeHeight >= OriginalHeight)
				return false;
		}

		if (Row == 0 || Row == Forest.size() - 1) {
			return true;
		} else {
			int RowChange = 0;
			if (direction == Direction.UP) {
				RowChange = -1;
			} else if (direction == Direction.DOWN) {
				RowChange = 1;
			}
			NewPosition[0] += RowChange;
		}
		if (Column == 0 || Column == Forest.get(Row).size() - 1) {
			return true;
		} else {
			int ColumnChange = 0;

			if (direction == Direction.LEFT)
				ColumnChange = -1;
			else if (direction == Direction.RIGHT)
				ColumnChange = 1;

			NewPosition[1] += ColumnChange;
		}

		return checkLine(Forest, NewPosition, OriginalPosition, OriginalHeight, direction);
	}

	public static void part2(ArrayList<ArrayList<Integer>> Forest) {
		int highestScore = 0;
		for (int i = 0; i < Forest.size(); i++) {
			ArrayList<Integer> TreeRow = Forest.get(i);
			for (int c = 0; c < Forest.get(i).size(); c++) {
				int Tree = TreeRow.get(c);
				int score = 1;
				for (Direction direction : Direction.values()) {
					int[] CurrPosition = new int[] { i, c };
					score *= checkView(Forest, CurrPosition, CurrPosition, Tree, direction, 0);
				}
				if (score > highestScore)
					highestScore = score;
			}
		}
		System.out.println(String.format("The highest possible score is %d", highestScore));
	}

	public static int checkView(ArrayList<ArrayList<Integer>> Forest, int[] Position, int[] OriginalPosition,
			int OriginalHeight, Direction direction, int currentScore) {
		int Row = Position[0];
		int Column = Position[1];
		int CurrentTreeHeight = Forest.get(Row).get(Column);

		int[] NewPosition = Position.clone();

		// ArrayList<Integer> ForestRow = Forest.get(Column)
		if (Row != OriginalPosition[0] ^ Column != OriginalPosition[1]) {
			if (CurrentTreeHeight >= OriginalHeight)
				return currentScore;
		}

		if (Row == 0 || Row == Forest.size() - 1) {
			return currentScore;
		} else {
			int RowChange = 0;
			if (direction == Direction.UP) {
				RowChange = -1;
			} else if (direction == Direction.DOWN) {
				RowChange = 1;
			}
			NewPosition[0] += RowChange;
		}
		if (Column == 0 || Column == Forest.get(Row).size() - 1) {
			return currentScore;
		} else {
			int ColumnChange = 0;

			if (direction == Direction.LEFT)
				ColumnChange = -1;
			else if (direction == Direction.RIGHT)
				ColumnChange = 1;

			NewPosition[1] += ColumnChange;
		}

		return checkView(Forest, NewPosition, OriginalPosition, OriginalHeight, direction, currentScore + 1);
	}
}
