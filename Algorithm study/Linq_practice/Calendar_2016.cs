public class Solution {
    public string solution(int a, int b) {
        string[] day_of_week = new string[]{"SUN","MON","TUE","WED","THU","FRI","SAT"};
        return day_of_week[a <= 2 ? ((a - 1) * 31 + b + 4) % 7 : a > 8 ? ((a - 8) * 31 - (a - 8) / 2 + b + 217) % 7 : ((a - 1) * 31 - (a - 1) / 2 - 1 + b + 4) % 7];
    }
}
