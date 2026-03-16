public class Solution {
    public bool IsRobotBounded(string instructions) {
        // Initial position
        int x = 0, y = 0;
        
        // Directions: North, East, South, West (Clockwise order)
        // North: (0, 1), East: (1, 0), South: (0, -1), West: (-1, 0)
        int[][] directions = new int[][] {
            new int[] {0, 1},  // Index 0: North
            new int[] {1, 0},  // Index 1: East
            new int[] {0, -1}, // Index 2: South
            new int[] {-1, 0}  // Index 3: West
        };
        
        int currentDir = 0; // Starts facing North (index 0)

        foreach (char i in instructions) {
            if (i == 'G') {
                x += directions[currentDir][0];
                y += directions[currentDir][1];
            } else if (i == 'L') {
                // Turn Left: Move counter-clockwise in our array
                // Adding 3 is the same as subtracting 1 (modulo 4)
                currentDir = (currentDir + 3) % 4;
            } else if (i == 'R') {
                // Turn Right: Move clockwise in our array
                currentDir = (currentDir + 1) % 4;
            }
        }

        // The robot is bounded if:
        // 1. It returned to the center (x == 0 && y == 0)
        // 2. OR it is NOT facing North (currentDir != 0)
        return (x == 0 && y == 0) || (currentDir != 0);
    }
}