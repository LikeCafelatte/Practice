
int T = int.Parse(Console.ReadLine());

for (int i = 0; i < T; i++)
{
    int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
    double[] radius = new double[] {input[2], input[5], Math.Sqrt((input[0] - input[3]) * (input[0] - input[3]) + (input[1] - input[4]) * (input[1] - input[4]))};
    Solution(radius);
}
void Solution(double[] radius){
    Array.Sort(radius);
    int answer = 0;
    if(radius[2] > radius[1] + radius[0]){
        answer = 0;
    }
    else if(radius[2] == radius[1] + radius[0]){
        answer = 1;
        if(radius[0] == 0) answer = -1;
    }
    else{
        answer = 2;
    }
    Console.WriteLine(answer);
}