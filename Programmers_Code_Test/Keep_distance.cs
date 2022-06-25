using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[,] places) {
        int[] answer = new int[places.GetLength(0)];
        List<bool[,]> pArrayList = new List<bool[,]>();
        List<bool[,]> xArrayList = new List<bool[,]>();
        for(int i = 0; i < 5; i++){
            bool[,] pArray = new bool[5,5];
            bool[,] xArray = new bool[5,5];
            for(int j = 0; j < 5; j++){
                for(int k = 0; k < 5; k++){
                    if(places[i,j].ToCharArray()[k] == 'P')
                        pArray[j, k] = true;
                    else if(places[i,j].ToCharArray()[k] == 'X')
                        xArray[j, k] = true;
                }
            }
            pArrayList.Add(pArray);
            xArrayList.Add(xArray);
        }
        for(int i = 0; i < places.GetLength(0); i++){
            bool[,] pArray = pArrayList[i];
            bool[,] xArray = xArrayList[i];
            answer[i] = 1;
            for(int j = 0; j < 5; j++)  for(int k = 0; k < 5; k ++) if(pArray[j, k]){
                bool[,] exploreArray = (bool[,])xArray.Clone();
                if(! Sol(pArray, xArray, exploreArray, j, k, 0)){
                    
                    answer[i] = 0;
                    j = 5;
                    k = 5;
                }
            }
            
        }
        return answer;
    }
    public bool Check(bool[,] Array, int j, int k){
        if(j >= 0 && k >= 0 && j < 5 && k < 5)
            return Array[j, k];
        return false;
    }
    public bool Sol(bool[,] pArray, bool[,] xArray, bool[,] exploreArray, int i, int j, int depth){
        exploreArray[i, j] = true;
        if(depth != 0) if(pArray[i,j]) return false;
        if(depth == 2) return true;
        return 
        (i > 0 && !exploreArray[i - 1, j] && !xArray[i - 1, j] ? Sol(pArray, xArray, exploreArray, i - 1, j, depth + 1) : true) &&
        (i < 4 && !exploreArray[i + 1, j] && !xArray[i + 1, j] ? Sol(pArray, xArray, exploreArray, i + 1, j, depth + 1) : true) &&
        (j > 0 && !exploreArray[i, j - 1] && !xArray[i, j - 1] ? Sol(pArray, xArray, exploreArray, i, j - 1, depth + 1) : true) &&
        (j < 4 && !exploreArray[i, j + 1] && !xArray[i, j + 1] ? Sol(pArray, xArray, exploreArray, i, j + 1, depth + 1) : true);
    }
}