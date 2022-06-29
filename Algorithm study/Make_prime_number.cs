using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    List<int> prime_num = new List<int>();
    public int solution(int[] nums)
    {
        if(!prime_num.Contains(2))
            prime_num.Add(2);
        Array.Sort(nums);
        int answer = 0;
        int max = nums[nums.Length - 3] + nums[nums.Length - 2] + nums[nums.Length - 1];
        if(max > prime_num.Max())
            Add_prime_num(max);
        
        for(int i = 0; i < nums.Length - 2; i++){
            for(int j = i + 1; j < nums.Length - 1; j++){
                for(int k = j + 1; k < nums.Length; k++){
                    if(prime_num.Contains(nums[i] + nums[j] + nums[k])){
                        answer++;
                        System.Console.WriteLine("[" + nums[i] + "," + nums[j] + "," + nums[k] + "]을 이용해서 " + (nums[i] + nums[j] + nums[k]).ToString() + "을 만들 수 있습니다.");
                    }
                }
            }
        }

        return answer;
    }
    public void Add_prime_num(int max){
        for(int i = prime_num.Max() + 1; i <= max; i++){
            bool isPrime = true;
            foreach(int n in prime_num){
                if(i % n == 0){
                    isPrime = false;
                    break;
                }
            }
            if(isPrime){
                prime_num.Add(i);
            }
        }
    }

    public int PrimeCheck(int num){
        if(num <= 1)
            return 0;
        if(num == 2 || num == 3)
            return 1;
        if(num == 4)
            return 0;
        
        for(int i = 2; Math.Pow(i, 2) < num; i++){
            if(num % i == 0)
                return 0;
        }
        return 1;
    }
}