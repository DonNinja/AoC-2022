package Day_10;

public class Main {
	static String colourStart = "\u001B[";
	
	public static void main(String[] args) {
		printError("This is a test");
		
		
	}

	public static void printError(String errorString) {
		System.out.println(String.format("%s31m", colourStart) + errorString);
		System.out.print(String.format("%s37m", colourStart));
	}
}
