using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string[] enroll, string[] referral, string[] seller, int[] amount) {
        int[] answer = new int[enroll.Length];
        //0. 변수 초기화
        Dictionary<string, Enrollment> enroll_dict = new Dictionary<string, Enrollment>();
        Enrollment center = new Enrollment("center", null);

        //1. eroll과 referral을 하나씩 읽으며 다단계 구조를 가진 enrollment 클래스 생성 및 Dictionary에 추가
        Enrollment temp_enroll;
        for(int i = 0; i < enroll.Length; i++){
            if(referral[i].Equals("-")) temp_enroll = new Enrollment(enroll[i], center);
            else temp_enroll = new Enrollment(enroll[i], enroll_dict[referral[i]]);
            enroll_dict.Add(enroll[i], temp_enroll);
        }

        //2. seller를 Dictionray에서 찾아 이익분배
        for(int i = 0; i < seller.Length; i++){
            enroll_dict[seller[i]].Selling_n_Bribe(amount[i] * 100);
        }

        for(int i = 0; i < enroll.Length; i++){
            answer[i] = enroll_dict[enroll[i]].profit;
        }
        return answer;
    }

    public class Enrollment{
        string enroll;
        Enrollment referral;
        public int profit = 0;

        public Enrollment(string enroll, Enrollment referral){
            this.enroll = enroll;
            this.referral = referral;
        }

        public void Selling_n_Bribe(int profit){
            if(referral == null){
                this.profit += profit;
                return;
            }
            if(profit / 10 == 0){
                this.profit += profit;
                return;
            }
            referral.Selling_n_Bribe(profit/10);
            this.profit += profit - (profit/10);
        }
    }
}