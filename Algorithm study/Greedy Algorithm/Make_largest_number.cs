using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public string solution(string number, int k) {
        int length = number.Length - k;
        char[] char_number = number.ToCharArray();
        Stack<char> stack = new Stack<char>();
        foreach(char c in char_number){
            while(stack.Count > 0 && stack.Peek() < c && k > 0){
                stack.Pop();
                k--;
            }
            stack.Push(c);
        }
        StringBuilder myStringBuilder = new StringBuilder("");
        char_number = stack.Reverse().ToArray();
        
        for(int i = 0; i < length; i++){
            myStringBuilder.Append(char_number[i]);
        }
        return myStringBuilder.ToString();
    }
}