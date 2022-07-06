using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string name) {
        int up_down = 0;
        char[] char_Array = name.ToCharArray();
        var bool_Array = char_Array.Select(c => c == 'A').ToArray();
        int left_right = GetLeftRight(bool_Array);

        for(int i = 0; i < char_Array.Length; i++){
            if((char_Array[i] - 'A') > ('Z' - char_Array[i] + 1))
                up_down += 'Z' - char_Array[i] + 1;
            else
                up_down += char_Array[i] - 'A';
        }
        if(left_right == -1) left_right = 0;

        return up_down + left_right;
    }

    public int GetLeftRight(bool[] bool_Array){
        int left_right = bool_Array.Length - 1;
        int temp = left_right;

        for(int i = 1; i < bool_Array.Length; i++){
            if(bool_Array[i]) left_right--;
            else
                break;
        }
        for(int i = bool_Array.Length - 1; i >= 0 ; i--){
            if(bool_Array[i]) temp--;
            else
                break;
        }
        if(temp < left_right) left_right = temp;
        Console.WriteLine(left_right);

        int length_A = 0;
        int backup_i = 0;
        for(int i = 1; i < bool_Array.Length; i++){
            if(bool_Array[i]){
                if(length_A == 0){
                    backup_i = i - 1;
                }
                length_A++;
            }
            else{
                if(length_A > 0){
                    if(backup_i > 0){
                        int temp_left_right = bool_Array.Length - length_A +  backup_i - 1;
                        if(left_right > temp_left_right){
                            left_right = temp_left_right;
                        }
                    }
                    length_A = 0;
                }
            }
        }
        Console.WriteLine(left_right);

        length_A = 0;
        backup_i = 0;
        for(int i = 0; i < bool_Array.Length; i++){
            if(bool_Array[bool_Array.Length - 1 - i]){
                if(length_A == 0){
                    backup_i = i - 1;
                }
                length_A++;
            }
            else{
                if(length_A > 0){
                    if(backup_i >= 0){
                        int temp_left_right = bool_Array.Length - length_A + backup_i;
                        if(left_right > temp_left_right){
                            left_right = temp_left_right;
                        }
                    }
                    length_A = 0;
                }
            }
        }
        Console.WriteLine(left_right);
        return left_right;
    }
}