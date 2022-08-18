using System;
using System.Collections.Generic;

public class Solution {
    public bool solution(string s) {
        Stack<char> stack = new Stack<char>();
        for(int i = 0; i < s.Length; i++){
            if(stack.Count == 0){
                if(s[i].Equals(')')) return false;
                stack.Push(s[i]);
                continue;
            }
            if(s[i].Equals(')')){
                stack.Pop();
            }else{
                stack.Push(s[i]);
            }
        }
        if(stack.Count > 0) return false;
        return true;
    }
}
