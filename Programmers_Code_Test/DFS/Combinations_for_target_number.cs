
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    List<int[]> ckList;
    int count = 0;
    public int solution(int[] numbers, int target) {
        ckList = new List<int[]>();
        int answer = 0;
        int[] signs = new int[numbers.Length].Select(i => 1).ToArray();
        int start = 0;
        if(numbers.Sum() < target)
            return 0;
        int[] tracing = new int[numbers.Length];
        int tracing_num = 0;
        int tracing_temp = tracing_num;
        
        for(int j = 0; j < Math.Pow(2, numbers.Length); j++){
            tracing_temp = tracing_num;
            int[] signs_test = (int[]) signs.Clone();
            
            for(int i = numbers.Length - 1; i >= 0; i--){
                tracing[i] = tracing_temp % 2;
                tracing_temp = tracing_temp / 2;
                signs_test[i] -= tracing[i] * 2;
            }
            
            if( numbers.Zip(signs_test, (n, s) => n*s).Sum() == target){
                answer++;
            }
            tracing_num++;
        }
        return answer;
    }
    public int DFS(int[] arr, int target, int idx, int num){
        if(idx == arr.Length){
            if(target == num)
                return 1;
            else
                return 0;
        }else
            return DFS(arr, target, idx + 1, num + arr[idx]) + DFS(arr, target, idx + 1, num - arr[idx]);
    }
}
/*
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    List<int[]> ckList;
    int count = 0;
    public int solution(int[] numbers, int target) {
        ckList = new List<int[]>();
        int answer = 0;
        int[] signs = new int[numbers.Length].Select(i => 1).ToArray();
        int start = 0;
        if(numbers.Sum() < target)
            return 0;
        Array.Sort(numbers);
        
        int[] new_signs = (int[])signs.Clone();
        new_signs[0] *= -1;
        return DFS(numbers, signs, start, target, answer) + DFS(numbers, new_signs, start, target, answer);
    }
    public int DFS(int[] numbers, int[] signs, int start, int target, int answer){
        //Console.WriteLine(count++);
        //    foreach(int s in signs)
        //    Console.Write(s + " ");
        //    Console.Write("\n");
        //Console.WriteLine(ckList.Count());
        //if(ckList.Where(array => array.Zip(signs, (n, s) => n*s).Sum() == signs.Length).Count() > 0){
        //    //Console.WriteLine("Wrong");
        //    return answer;
        //}
        
        
        if(ckList.Where(array => array.Zip(signs, (n, s) => n*s).Sum() == signs.Length).Count() == 0 && numbers.Zip(signs, (n, s) => n*s).Sum() == target){
            answer++;
            ckList.Add(signs);
            //Console.Write("answer: ");
            //foreach(int s in signs)
            //Console.Write(s + " ");
            //Console.Write("\n");
        }
        //if(numbers.Zip(signs, (n, s) => n*s).Sum() <= target)
        //    return answer;
        
        // if(start > 0){
        //     //Console.WriteLine("1 sequence");
        //     int[] new_signs = (int[])signs.Clone();
        //     new_signs[start-1] *= -1;
        //     answer = DFS(numbers, new_signs, start-1, target, answer);
        // }
        if(start < numbers.Length - 1){
            //Console.WriteLine("2 sequence");
            //int[] new_signs = (int[])signs.Clone();
            //new_signs[start+1] *= -1;
            //answer = DFS(numbers, new_signs, start+1, target, answer);
            //int[] new_signs2 = (int[])signs.Clone();
            //answer = DFS(numbers, new_signs2, start+1, target, answer);
            
            int[] new_signs = (int[])signs.Clone();
            new_signs[start+1] *= -1;
            //int[] new_signs2 = (int[])signs.Clone();
            //new_signs2[start] *= -1;
            answer = DFS(numbers, signs, start+1, target, answer);
            answer = DFS(numbers, new_signs, start+1, target, answer);
            //answer = DFS(numbers, new_signs2, start, target, answer);
        }
        //Console.WriteLine("3 sequence");
        //int[] new_signs3 = (int[])signs.Clone();
        //new_signs3[start] *= -1;
        //return DFS(numbers, new_signs3, start, target, answer);
        return answer;
    }
}*/