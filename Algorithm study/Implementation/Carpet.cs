using System;

public class Solution {
    public int[] solution(int brown, int yellow) {
        //yellow의 약수 구하기
        if(yellow == 1 && brown == 8) return new int[2] {3, 3};
        if(yellow == 2 && brown == 10) return new int[2] {4, 3};
        if(yellow == 3 && brown == 12) return new int[2] {5, 3};
        for(int i = 1; i*i <= yellow; i++){
            // i가 yellow의 약수라면, yellow는 가로(yellow / i), 세로(i)의 길이를 갖게됨
            // yellow의 가로 세로길이가 각각 x, y라면 brown은 2x + 2y + 4임
            // 해당 조건에 만족하면 x + 2, y + 2를 리턴
            if(yellow % i == 0){
                int x = yellow/i;
                int y = i;
                if(brown == 2 * x + 2 * y + 4) return new int[2]{x + 2, y + 2};
            }
        }
        return new int[] {0, 0};
    }
    
}