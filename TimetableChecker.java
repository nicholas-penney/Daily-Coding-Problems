/*******************

Brief:
Given an array of time intervals (start, end) for classroom lectures (possibly overlapping)
	find the minimum number of rooms requires.

Input:
[30,  75]
[0,   50]
[60, 150]

Should return: 2

******************/*


import java.util.*;

public class TimetableChecker {

    public static void main(String[] args) {
    
    		// Input timetable here as: {start, end}
        int[][] timeTablesArrArr = { {30, 75}, {0, 50}, {60, 150} };

    		// Classes active at current node in iteration
        int currentCount;
        
        	// Holder for highest minimum rooms needed found so fo
        int max = 0;



        	// Save time by not checking identical start/end times multiple times unecessarily
        Set<Integer> hashSet = new HashSet<Integer>();

        for (int i=0; i<timeTablesArrArr.length; i++){
        	for (int j=0; j<timeTablesArrArr[i].length; j++){
        		hashSet.add(timeTablesArrArr[i][j]);
        	}
        }

        	// Add convert HashSet to Integer Array to get start/end times as nodes
          // We'll count active classes at only those node times
        Integer[] nodes = hashSet.toArray(new Integer[hashSet.size()]);




        	// This loops through each node
		for (int i=0; i<nodes.length; i++){
        		
        		// At each node check, reset counter to zero
        	currentCount = 0;
          
        		// Pass current node value to buffer to make loop more readable
        	int buffer = nodes[i];
        		
        		// This loops through each class to see if the node value lies between j's schedule
            for (int j=0; j<timeTablesArrArr.length; j++){
        			// True if node time is while a class is already happening
        		if (buffer >= timeTablesArrArr[j][0] && buffer < timeTablesArrArr[j][1] ){
        			currentCount++;
        		}
        	} // End of (j-loop) through class timetables

        		// Now we have cycled the current hashSet buffer value through all classes and added up currently needed rooms.
        		// If this is new record, update max.
        	if (currentCount > max){
        		max = currentCount;
        	}

        } // End of (i-loop) through nodes
        

        System.out.println("Minimum number of rooms needed: " + Integer.toString(max));
        


    } // End of main

} // End of TimetableChecker class
